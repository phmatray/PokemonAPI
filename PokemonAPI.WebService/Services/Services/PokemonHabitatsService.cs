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
    public class PokemonHabitatsService : IPokemonHabitatsService
    {
        private readonly VeekunContext _context;

        public PokemonHabitatsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.PokemonHabitats.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonHabitats, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .PokemonHabitats
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<PokemonHabitat> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<PokemonHabitat> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<PokemonHabitat> Get(Expression<Func<EFPokemonHabitats, bool>> predicate)
        {
            var pokemonHabitat = await _context
                .PokemonHabitats
                .AsNoTracking()
                .Include(x => x.PokemonHabitatNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.PokemonSpecies)
                .FirstOrDefaultAsync(predicate);

            if (pokemonHabitat == null)
                return null;

            return new PokemonHabitat
            {
                Id = pokemonHabitat.Id,
                Name = pokemonHabitat.Identifier,
                Names = GetNames(pokemonHabitat),
                PokemonSpecies = GetPokemonSpecies(pokemonHabitat)
            };
        }

        private static List<Name> GetNames(EFPokemonHabitats pokemonHabitat)
        {
            return pokemonHabitat
                .PokemonHabitatNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFPokemonHabitats pokemonHabitat)
        {
            return pokemonHabitat
                .PokemonSpecies
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}