using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class PokeathlonStatsCacheService : IPokeathlonStatsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<PokeathlonStatsCacheService> _logger;
        private readonly IPokeathlonStatsService _pokeathlonStatsService;
        private readonly string _typeName;

        public PokeathlonStatsCacheService(
            IMemoryCache memoryCache,
            ILogger<PokeathlonStatsCacheService> logger,
            IPokeathlonStatsService pokeathlonStatsService)
        {
            _memoryCache            = memoryCache;
            _logger                 = logger;
            _pokeathlonStatsService = pokeathlonStatsService;
            _typeName               = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _pokeathlonStatsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _pokeathlonStatsService.GetAll(limit, offset));

        public async Task<PokeathlonStat> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _pokeathlonStatsService.Get(id));

        public async Task<PokeathlonStat> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _pokeathlonStatsService.Get(name));
    }
}