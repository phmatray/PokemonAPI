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
    public class EggGroupsService : IEggGroupsService
    {
        private readonly VeekunContext _context;

        public EggGroupsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.EggGroups.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFEggGroups, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .EggGroups
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<EggGroup> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<EggGroup> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<EggGroup> Get(Expression<Func<EFEggGroups, bool>> predicate)
        {
            var eggGroup = await _context
                .EggGroups
                .AsNoTracking()
                .Include(x => x.EggGroupProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.PokemonEggGroups).ThenInclude(x => x.Species)
                .FirstOrDefaultAsync(predicate);

            if (eggGroup == null)
                return null;

            return new EggGroup
            {
                Id             = eggGroup.Id,
                Name           = eggGroup.Identifier,
                Names          = GetNames(eggGroup),
                PokemonSpecies = GetPokemonSpecies(eggGroup)
            };
        }

        private static List<Name> GetNames(EFEggGroups eggGroup)
        {
            return eggGroup
                .EggGroupProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFEggGroups eggGroup)
        {
            return eggGroup
                .PokemonEggGroups
                .Select(x => x.Species.ToNamedApiResource())
                .ToList();
        }
    }
}