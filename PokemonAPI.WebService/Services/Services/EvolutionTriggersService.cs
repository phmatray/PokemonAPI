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
    public class EvolutionTriggersService : IEvolutionTriggersService
    {
        private readonly VeekunContext _context;

        public EvolutionTriggersService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.EvolutionTriggers.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFEvolutionTriggers, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .EvolutionTriggers
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<EvolutionTrigger> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<EvolutionTrigger> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<EvolutionTrigger> Get(Expression<Func<EFEvolutionTriggers, bool>> predicate)
        {
            var evolutionTrigger = await _context.EvolutionTriggers
                .AsNoTracking()
                .Include(x => x.EvolutionTriggerProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.PokemonEvolution).ThenInclude(x => x.EvolvedSpecies)
                .FirstOrDefaultAsync(predicate);

            if (evolutionTrigger == null)
                return null;

            return new EvolutionTrigger
            {
                Id             = evolutionTrigger.Id,
                Name           = evolutionTrigger.Identifier,
                Names          = GetNames(evolutionTrigger),
                PokemonSpecies = GetPokemonSpecies(evolutionTrigger)
            };
        }

        private static List<Name> GetNames(EFEvolutionTriggers evolutionTrigger)
        {
            return evolutionTrigger
                .EvolutionTriggerProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFEvolutionTriggers evolutionTrigger)
        {
            return evolutionTrigger
                .PokemonEvolution
                .Select(x => x.EvolvedSpecies.ToNamedApiResource())
                .ToList();
        }
    }
}