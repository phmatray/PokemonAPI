using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class PokedexesCacheService : IPokedexesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<PokedexesCacheService> _logger;
        private readonly IPokedexesService _pokedexesService;
        private readonly string _typeName;

        public PokedexesCacheService(
            IMemoryCache memoryCache,
            ILogger<PokedexesCacheService> logger,
            IPokedexesService pokedexesService)
        {
            _memoryCache      = memoryCache;
            _logger           = logger;
            _pokedexesService = pokedexesService;
            _typeName         = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _pokedexesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _pokedexesService.GetAll(limit, offset));

        public async Task<Pokedex> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _pokedexesService.Get(id));

        public async Task<Pokedex> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _pokedexesService.Get(name));
    }
}