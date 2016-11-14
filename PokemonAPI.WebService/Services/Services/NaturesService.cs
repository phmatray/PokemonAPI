using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.Services
{
    public class NaturesService : INaturesService
    {
        private readonly VeekunContext _context;

        public NaturesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Natures.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFNatures, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Natures
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Nature> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Nature> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Nature> Get(Expression<Func<EFNatures, bool>> predicate)
        {
            var nature = await _context
                .Natures
                .AsNoTracking()
                .Include(x => x.DecreasedStat)
                .Include(x => x.IncreasedStat)
                .Include(x => x.HatesFlavor).ThenInclude(x => x.ContestTypeNames)
                .Include(x => x.LikesFlavor).ThenInclude(x => x.ContestTypeNames)
                .Include(x => x.NaturePokeathlonStats).ThenInclude(x => x.PokeathlonStat)
                .Include(x => x.NatureBattleStylePreferences).ThenInclude(x => x.MoveBattleStyle)
                .Include(x => x.NatureNames).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (nature == null)
                return null;

            return new Nature
            {
                Id                         = nature.Id,
                Name                       = nature.Identifier,
                DecreasedStat              = GetDecreasedStat(nature),
                IncreasedStat              = GetIncreasedStat(nature),
                HatesFlavor                = GetHatesFlavor(nature),
                LikesFlavor                = GetLikesFlavor(nature),
                PokeathlonStatChanges      = GetPokeathlonStatChanges(nature),
                MoveBattleStylePreferences = GetMoveBattleStylePreferences(nature),
                Names                      = GetNames(nature)
            };
        }

        private static NamedAPIResource GetDecreasedStat(EFNatures nature)
        {
            return nature
                .DecreasedStat
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetIncreasedStat(EFNatures nature)
        {
            return nature
                .IncreasedStat
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetHatesFlavor(EFNatures nature)
        {
            var flavor = nature
                .HatesFlavor
                .ContestTypeNames
                .FirstOrDefault(x => x.LocalLanguageId == 9);

            if (flavor == null)
                return null;

            return new NamedAPIResource
            (
                flavor.Flavor.ToLower(),
                typeof(BerryFlavorsController).RscUrl(flavor.ContestTypeId)
            );
        }

        private static NamedAPIResource GetLikesFlavor(EFNatures nature)
        {
            var flavor = nature
                .LikesFlavor
                .ContestTypeNames
                .FirstOrDefault(x => x.LocalLanguageId == 9);

            if (flavor == null)
                return null;

            return new NamedAPIResource
            (
                flavor.Flavor.ToLower(),
                typeof(BerryFlavorsController).RscUrl(flavor.ContestTypeId)
            );
        }

        private static List<NatureStatChange> GetPokeathlonStatChanges(EFNatures nature)
        {
            return nature
                .NaturePokeathlonStats
                .Select(x => new NatureStatChange
                {
                    MaxChange = x.MaxChange,
                    PokeathlonStat = x.PokeathlonStat.ToNamedApiResource()
                })
                .ToList();
        }

        private static List<MoveBattleStylePreference> GetMoveBattleStylePreferences(EFNatures nature)
        {
            return nature
                .NatureBattleStylePreferences
                .Select(x => new MoveBattleStylePreference
                {
                    HighHpPreference = x.HighHpPreference,
                    LowHpPreference = x.LowHpPreference,
                    MoveBattleStyle = x.MoveBattleStyle.ToNamedApiResource()
                })
                .ToList();
        }

        private static List<Name> GetNames(EFNatures nature)
        {
            return nature
                .NatureNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}