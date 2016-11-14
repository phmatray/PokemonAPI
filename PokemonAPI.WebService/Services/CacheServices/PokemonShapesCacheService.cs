using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class PokemonShapesCacheService : IPokemonShapesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<PokemonShapesCacheService> _logger;
        private readonly IPokemonShapesService _pokemonShapesService;
        private readonly string _typeName;

        public PokemonShapesCacheService(
            IMemoryCache memoryCache,
            ILogger<PokemonShapesCacheService> logger,
            IPokemonShapesService pokemonShapesService)
        {
            _memoryCache          = memoryCache;
            _logger               = logger;
            _pokemonShapesService = pokemonShapesService;
            _typeName             = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _pokemonShapesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _pokemonShapesService.GetAll(limit, offset));

        public async Task<PokemonShape> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _pokemonShapesService.Get(id));

        public async Task<PokemonShape> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _pokemonShapesService.Get(name));
    }
}