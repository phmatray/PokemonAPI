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
    public class VersionGroupsService : IVersionGroupsService
    {
        private readonly VeekunContext _context;

        public VersionGroupsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.VersionGroups.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFVersionGroups, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .VersionGroups
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<VersionGroup> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<VersionGroup> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<VersionGroup> Get(Expression<Func<EFVersionGroups, bool>> predicate)
        {
            var versionGroup = await _context.VersionGroups
                .AsNoTracking()
                .Include(x => x.VersionGroupPokemonMoveMethods).ThenInclude(x => x.PokemonMoveMethod)
                .Include(x => x.Versions)
                .Include(x => x.Generation)
                .Include(x => x.VersionGroupRegions).ThenInclude(x => x.Region)
                .Include(x => x.PokedexVersionGroups).ThenInclude(x => x.Pokedex)
                .FirstOrDefaultAsync(predicate);

            if (versionGroup == null)
                return null;

            return new VersionGroup
            {
                Id               = versionGroup.Id,
                Name             = versionGroup.Identifier,
                Order            = versionGroup.Order,
                MoveLearnMethods = GetMoveLearnMethods(versionGroup),
                Versions         = GetVersions(versionGroup),
                Generation       = GetGeneration(versionGroup),
                Regions          = GetRegions(versionGroup),
                Pokedexes        = GetPokedexes(versionGroup)
            };
        }

        private static List<NamedAPIResource> GetMoveLearnMethods(EFVersionGroups versionGroup)
        {
            return versionGroup
                .VersionGroupPokemonMoveMethods
                .Select(x => x.PokemonMoveMethod?.ToNamedApiResource())
                .ToList();
        }

        private static List<NamedAPIResource> GetVersions(EFVersionGroups versionGroup)
        {
            return versionGroup
                .Versions
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static NamedAPIResource GetGeneration(EFVersionGroups versionGroup)
        {
            return versionGroup
                .Generation?
                .ToNamedApiResource();
        }

        private static List<NamedAPIResource> GetRegions(EFVersionGroups versionGroup)
        {
            return versionGroup
                .VersionGroupRegions
                .Select(x => x.Region?.ToNamedApiResource())
                .ToList();
        }

        private static List<NamedAPIResource> GetPokedexes(EFVersionGroups versionGroup)
        {
            return versionGroup
                .PokedexVersionGroups
                .Select(x => x.Pokedex?.ToNamedApiResource())
                .ToList();
        }
    }
}