using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class PokemonsCacheService : IPokemonsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<PokemonsCacheService> _logger;
        private readonly IPokemonsService _pokemonsService;
        private readonly string _typeName;

        public PokemonsCacheService(
            IMemoryCache memoryCache,
            ILogger<PokemonsCacheService> logger,
            IPokemonsService pokemonsService)
        {
            _memoryCache     = memoryCache;
            _logger          = logger;
            _pokemonsService = pokemonsService;
            _typeName        = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _pokemonsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _pokemonsService.GetAll(limit, offset));

        public async Task<Pokemon> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _pokemonsService.Get(id));

        public async Task<Pokemon> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _pokemonsService.Get(name));

        public async Task<List<LocationAreaEncounter>> GetEncounters(int pokemonId)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetEncounters-{pokemonId}",
                entry => _pokemonsService.GetEncounters(pokemonId));

        public async Task<List<LocationAreaEncounter>> GetEncounters(string pokemonName)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetEncounters-{pokemonName}",
                entry => _pokemonsService.GetEncounters(pokemonName));
    }
}