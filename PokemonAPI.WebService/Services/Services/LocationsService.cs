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
    public class LocationsService : ILocationsService
    {
        private readonly VeekunContext _context;

        public LocationsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Locations.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFLocations, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Locations
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Location> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Location> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Location> Get(Expression<Func<EFLocations, bool>> predicate)
        {
            var location = await _context.Locations
                .AsNoTracking()
                .Include(x => x.Region)
                .Include(x => x.LocationNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.LocationGameIndices).ThenInclude(x => x.Generation)
                .Include(x => x.LocationAreas)
                .FirstOrDefaultAsync(predicate);

            if (location == null)
                return null;

            return new Location
            {
                Id          = location.Id,
                Name        = location.Identifier,
                Region      = GetRegion(location),
                Names       = GetNames(location),
                GameIndices = GetGameIndices(location),
                Areas       = GetAreas(location)
            };
        }

        private static NamedAPIResource GetRegion(EFLocations location)
        {
            return location.Region
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFLocations location)
        {
            return location
                .LocationNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<GenerationGameIndex> GetGameIndices(EFLocations location)
        {
            return location
                .LocationGameIndices
                .Select(x => new GenerationGameIndex(x.GameIndex, x.Generation.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetAreas(EFLocations location)
        {
            return location
                .LocationAreas
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}