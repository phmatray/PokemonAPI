using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.Services
{
    public class LocationAreasService : ILocationAreasService
    {
        private readonly VeekunContext _context;

        public LocationAreasService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.LocationAreas.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFLocationAreas, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .LocationAreas
                .AsNoTracking()
                .Include(x => x.Location)
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<LocationArea> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<LocationArea> Get(string name)
        {
            return await Get(x => (x.Identifier == null
                                      ? $"{x.Location.Identifier}-area"
                                      : $"{x.Location.Identifier}-{x.Identifier}") == name);
        }

        public async Task<LocationArea> Get(Expression<Func<EFLocationAreas, bool>> predicate)
        {
            var locationArea = await _context.LocationAreas
                .AsNoTracking()
                .Include(x => x.Location)
                .Include(x => x.LocationAreaEncounterRates).ThenInclude(x => x.EncounterMethod)
                .Include(x => x.LocationAreaEncounterRates).ThenInclude(x => x.Version)
                .Include(x => x.LocationAreaProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.Encounters).ThenInclude(x => x.Pokemon)
                .Include(x => x.Encounters).ThenInclude(x => x.Version)
                .Include(x => x.Encounters).ThenInclude(x => x.Version)
                .Include(x => x.Encounters).ThenInclude(x => x.EncounterSlot).ThenInclude(x => x.EncounterMethod)
                .FirstOrDefaultAsync(predicate);

            if (locationArea == null)
                return null;

            return new LocationArea
            {
                Id                   = locationArea.Id,
                Name                 = GetName(locationArea),
                GameIndex            = locationArea.GameIndex,
                EncounterMethodRates = GetEncounterMethodRates(locationArea),
                Location             = GetLocation(locationArea),
                Names                = GetNames(locationArea),
                PokemonEncounters    = GetPokemonEncounters(locationArea)
            };
        }

        private static string GetName(EFLocationAreas locationArea)
        {
            return $"{locationArea.Location.Identifier}-{locationArea.Identifier ?? "area"}";
        }

        private static List<EncounterMethodRate> GetEncounterMethodRates(EFLocationAreas locationArea)
        {
            return locationArea
                .LocationAreaEncounterRates
                .GroupBy(x => x.EncounterMethodId,
                    (key, group) =>
                    {
                        var efLocationAreaEncounterRateses = group as IList<EFLocationAreaEncounterRates> ?? group.ToList();

                        var encounterMethod = efLocationAreaEncounterRateses
                            .FirstOrDefault()?
                            .EncounterMethod
                            .ToNamedApiResource();

                        var encounterVersionDetails = efLocationAreaEncounterRateses
                            .Select(g => new EncounterVersionDetails(g.Rate, g.Version.ToNamedApiResource()))
                            .ToList();

                        return new EncounterMethodRate(encounterMethod, encounterVersionDetails);
                    })
                .ToList();
        }

        private static NamedAPIResource GetLocation(EFLocationAreas locationArea)
        {
            return locationArea
                .Location
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFLocationAreas locationArea)
        {
            return locationArea
                .LocationAreaProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<PokemonEncounter> GetPokemonEncounters(EFLocationAreas locationArea)
        {
            return locationArea
                .Encounters
                .GroupBy(x => x.PokemonId,
                    (key, group) =>
                    {
                        var efEncounterses = group as IList<EFEncounters> ?? group.ToList();

                        var pokemon = efEncounterses
                            .FirstOrDefault()?
                            .Pokemon
                            .ToNamedApiResource();

                        var versionEncounterDetails = efEncounterses
                            .GroupBy(x2 => x2.Version.Id,
                                (key2, group2) =>
                                {
                                    var encounters = group2 as IList<EFEncounters> ?? group2.ToList();
                                    return GetVersionEncounterDetails(encounters);
                                })
                            .ToList();

                        return new PokemonEncounter(pokemon, versionEncounterDetails);
                    })
                .ToList();
        }

        private static VersionEncounterDetail GetVersionEncounterDetails(IList<EFEncounters> encounterses)
        {
            var version = encounterses
                .FirstOrDefault()?
                .Version
                .ToNamedApiResource();

            var maxChance = encounterses
                .Sum(encounters => encounters.EncounterSlot.Rarity ?? 0);

            var encounterDetails = encounterses
                .Select(encounters =>
                {
                    var conditionValues = encounters
                        .EncounterConditionValueMap
                        .Select(cv => cv.EncounterConditionValue.ToNamedApiResource())
                        .ToList();

                    var method = encounters
                        .EncounterSlot
                        .EncounterMethod
                        .ToNamedApiResource();

                    return new Encounter(encounters.MinLevel, encounters.MaxLevel, conditionValues,
                        encounters.EncounterSlot.Rarity, method);
                })
                .ToList();

            return new VersionEncounterDetail(version, maxChance, encounterDetails);
        }
    }
}