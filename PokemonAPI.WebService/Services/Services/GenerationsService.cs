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
    public class GenerationsService : IGenerationsService
    {
        private readonly VeekunContext _context;

        public GenerationsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Generations.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFGenerations, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Generations
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Generation> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Generation> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Generation> Get(Expression<Func<EFGenerations, bool>> predicate)
        {
            var generation = await _context.Generations
                .AsNoTracking()
                .Include(x => x.MainRegion)
                .Include(x => x.GenerationNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.VersionGroups)
                .Include(x => x.PokemonSpecies)
                .Include(x => x.Moves)
                .Include(x => x.Types)
                .Include(x => x.Abilities)
                .FirstOrDefaultAsync(predicate);

            if (generation == null)
                return null;

            return new Generation
            {
                Id             = generation.Id,
                Name           = generation.Identifier,
                Abilities      = GetAbilities(generation),
                VersionGroups  = GetVersionGroups(generation),
                Names          = GetNames(generation),
                PokemonSpecies = GetPokemonSpecies(generation),
                Moves          = GetMoves(generation),
                MainRegion     = GetMainRegion(generation),
                Types          = GetTypes(generation)
            };
        }

        private static List<NamedAPIResource> GetTypes(EFGenerations generation)
        {
            return generation
                .Types
                .Where(x => x.Id < 10000)
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static NamedAPIResource GetMainRegion(EFGenerations generation)
        {
            return generation
                .MainRegion
                .ToNamedApiResource();
        }

        private static List<NamedAPIResource> GetMoves(EFGenerations generation)
        {
            return generation
                .Moves
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFGenerations generation)
        {
            return generation
                .PokemonSpecies
                .OrderBy(x => x.Id)
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFGenerations generation)
        {
            return generation
                .GenerationNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetVersionGroups(EFGenerations generation)
        {
            return generation
                .VersionGroups
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<NamedAPIResource> GetAbilities(EFGenerations generation)
        {
            return generation
                .Abilities
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}