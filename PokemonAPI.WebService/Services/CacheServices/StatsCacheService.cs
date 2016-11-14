using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class StatsCacheService : IStatsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<StatsCacheService> _logger;
        private readonly IStatsService _statsService;
        private readonly string _typeName;

        public StatsCacheService(
            IMemoryCache memoryCache,
            ILogger<StatsCacheService> logger,
            IStatsService statsService)
        {
            _memoryCache  = memoryCache;
            _logger       = logger;
            _statsService = statsService;
            _typeName     = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _statsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _statsService.GetAll(limit, offset));

        public async Task<Stat> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _statsService.Get(id));

        public async Task<Stat> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _statsService.Get(name));
    }
}