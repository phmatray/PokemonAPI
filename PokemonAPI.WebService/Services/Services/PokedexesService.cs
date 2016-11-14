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
    public class PokedexesService : IPokedexesService
    {
        private readonly VeekunContext _context;

        public PokedexesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Pokedexes.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokedexes, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Pokedexes
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Pokedex> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Pokedex> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Pokedex> Get(Expression<Func<EFPokedexes, bool>> predicate)
        {
            var pokedex = await _context.Pokedexes
                .AsNoTracking()
                .Include(x => x.Region)
                .Include(x => x.PokedexVersionGroups).ThenInclude(x => x.VersionGroup)
                .Include(x => x.PokedexProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.PokemonDexNumbers).ThenInclude(x => x.Species)
                .FirstOrDefaultAsync(predicate);

            if (pokedex == null)
                return null;

            return new Pokedex
            {
                Id             = pokedex.Id,
                Name           = pokedex.Identifier,
                IsMainSeries   = pokedex.IsMainSeries,
                Region         = GetRegion(pokedex),
                VersionGroups  = GetVersionGroups(pokedex),
                Descriptions   = GetDescriptions(pokedex),
                PokemonEntries = GetEntries(pokedex),
                Names          = GetNames(pokedex)
            };
        }

        private static NamedAPIResource GetRegion(EFPokedexes pokedex)
        {
            return pokedex
                .Region?
                .ToNamedApiResource();
        }

        private static List<NamedAPIResource> GetVersionGroups(EFPokedexes pokedex)
        {
            return pokedex
                .PokedexVersionGroups
                .Select(x => x.VersionGroup.ToNamedApiResource())
                .ToList();
        }

        private static List<Description> GetDescriptions(EFPokedexes pokedex)
        {
            return pokedex
                .PokedexProse
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<PokemonEntry> GetEntries(EFPokedexes pokedex)
        {
            return pokedex
                .PokemonDexNumbers
                .OrderBy(x => x.PokedexNumber)
                .Select(x => new PokemonEntry(x.PokedexNumber, x.Species.ToNamedApiResource()))
                .ToList();
        }

        private static List<Name> GetNames(EFPokedexes pokedex)
        {
            return pokedex
                .PokedexProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}