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
    public class PokemonColorsService : IPokemonColorsService
    {
        private readonly VeekunContext _context;

        public PokemonColorsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.PokemonColors.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonColors, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .PokemonColors
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<PokemonColor> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<PokemonColor> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<PokemonColor> Get(Expression<Func<EFPokemonColors, bool>> predicate)
        {
            var pokemonColor = await _context
                .PokemonColors
                .AsNoTracking()
                .Include(x => x.PokemonColorNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.PokemonSpecies)
                .FirstOrDefaultAsync(predicate);

            if (pokemonColor == null)
                return null;

            return new PokemonColor
            {
                Id             = pokemonColor.Id,
                Name           = pokemonColor.Identifier,
                Names          = GetNames(pokemonColor),
                PokemonSpecies = GetPokemonSpecies(pokemonColor)
            };
        }

        private static List<Name> GetNames(EFPokemonColors pokemonColor)
        {
            return pokemonColor
                .PokemonColorNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFPokemonColors pokemonColor)
        {
            return pokemonColor
                .PokemonSpecies
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}