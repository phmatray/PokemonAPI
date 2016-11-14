using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class PokemonColorsCacheService : IPokemonColorsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<PokemonColorsCacheService> _logger;
        private readonly IPokemonColorsService _pokemonColorsService;
        private readonly string _typeName;

        public PokemonColorsCacheService(
            IMemoryCache memoryCache,
            ILogger<PokemonColorsCacheService> logger,
            IPokemonColorsService pokemonColorsService)
        {
            _memoryCache          = memoryCache;
            _logger               = logger;
            _pokemonColorsService = pokemonColorsService;
            _typeName             = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _pokemonColorsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _pokemonColorsService.GetAll(limit, offset));

        public async Task<PokemonColor> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _pokemonColorsService.Get(id));

        public async Task<PokemonColor> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _pokemonColorsService.Get(name));
    }
}