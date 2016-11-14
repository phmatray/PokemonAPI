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
    
    public class RegionsService : IRegionsService
    {
        private readonly VeekunContext _context;

        public RegionsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Regions.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFRegions, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Regions
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Region> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Region> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Region> Get(Expression<Func<EFRegions, bool>> predicate)
        {
            var region = await _context.Regions
                .AsNoTracking()
                .Include(x => x.Locations)
                .Include(x => x.VersionGroupRegions).ThenInclude(x => x.VersionGroup)
                .Include(x => x.RegionNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.Generations)
                .Include(x => x.Pokedexes)
                .FirstOrDefaultAsync(predicate);

            if (region == null)
                return null;

            return new Region
            {
                Id             = region.Id,
                Name           = region.Identifier,
                Locations      = GetLocations(region),
                VersionGroups  = GetVersionGroups(region),
                Names          = GetNames(region),
                MainGeneration = GetMainGeneration(region),
                Pokedexes      = GetPokedexes(region)
            };
        }

        private static List<NamedAPIResource> GetLocations(EFRegions region)
        {
            return region
                .Locations
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<NamedAPIResource> GetVersionGroups(EFRegions region)
        {
            return region
                .VersionGroupRegions
                .Select(x => x.VersionGroup.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFRegions region)
        {
            return region
                .RegionNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static NamedAPIResource GetMainGeneration(EFRegions region)
        {
            return region
                .Generations
                .FirstOrDefault(x => x.MainRegionId == region.Id)?
                .ToNamedApiResource();
        }

        private static List<NamedAPIResource> GetPokedexes(EFRegions region)
        {
            return region
                .Pokedexes
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}