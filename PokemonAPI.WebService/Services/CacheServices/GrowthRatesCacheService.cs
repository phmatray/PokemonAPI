using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class GrowthRatesCacheService : IGrowthRatesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<GrowthRatesCacheService> _logger;
        private readonly IGrowthRatesService _growthRatesService;
        private readonly string _typeName;

        public GrowthRatesCacheService(
            IMemoryCache memoryCache,
            ILogger<GrowthRatesCacheService> logger,
            IGrowthRatesService growthRatesService)
        {
            _memoryCache        = memoryCache;
            _logger             = logger;
            _growthRatesService = growthRatesService;
            _typeName           = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _growthRatesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _growthRatesService.GetAll(limit, offset));

        public async Task<GrowthRate> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _growthRatesService.Get(id));

        public async Task<GrowthRate> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _growthRatesService.Get(name));
    }
}