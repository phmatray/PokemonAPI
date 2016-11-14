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
    public class PokemonShapesService : IPokemonShapesService
    {
        private readonly VeekunContext _context;

        public PokemonShapesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.PokemonShapes.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonShapes, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .PokemonShapes
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<PokemonShape> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<PokemonShape> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<PokemonShape> Get(Expression<Func<EFPokemonShapes, bool>> predicate)
        {
            var pokemonShape = await _context
                .PokemonShapes
                .AsNoTracking()
                .Include(x => x.PokemonShapeProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.PokemonSpecies)
                .FirstOrDefaultAsync(predicate);

            if (pokemonShape == null)
                return null;

            return new PokemonShape
            {
                Id = pokemonShape.Id,
                Name = pokemonShape.Identifier,
                AwesomeNames = GetAwesomeNames(pokemonShape),
                Descriptions = GetDescriptions(pokemonShape),
                Names = GetNames(pokemonShape),
                PokemonSpecies = GetPokemonSpecies(pokemonShape)
            };
        }

        private static List<AwesomeName> GetAwesomeNames(EFPokemonShapes pokemonShape)
        {
            return pokemonShape
                .PokemonShapeProse
                .Select(x => new AwesomeName(x.AwesomeName, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<Description> GetDescriptions(EFPokemonShapes pokemonShape)
        {
            return pokemonShape
                .PokemonShapeProse
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<Name> GetNames(EFPokemonShapes pokemonShape)
        {
            return pokemonShape
                .PokemonShapeProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFPokemonShapes pokemonShape)
        {
            return pokemonShape
                .PokemonSpecies
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}