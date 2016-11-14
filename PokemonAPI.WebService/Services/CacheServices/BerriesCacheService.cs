using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class BerriesCacheService : IBerriesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<BerriesCacheService> _logger;
        private readonly IBerriesService _berriesService;
        private readonly string _typeName;

        public BerriesCacheService(
            IMemoryCache memoryCache,
            ILogger<BerriesCacheService> logger,
            IBerriesService berriesService)
        {
            _memoryCache    = memoryCache;
            _logger         = logger;
            _berriesService = berriesService;
            _typeName       = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _berriesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _berriesService.GetAll(limit, offset));

        public async Task<Berry> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _berriesService.Get(id));

        public async Task<Berry> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _berriesService.Get(name));
    }
}