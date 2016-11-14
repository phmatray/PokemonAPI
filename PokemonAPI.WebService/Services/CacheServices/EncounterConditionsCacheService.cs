using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class EncounterConditionsCacheService : IEncounterConditionsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<EncounterConditionsCacheService> _logger;
        private readonly IEncounterConditionsService _encounterConditionsService;
        private readonly string _typeName;

        public EncounterConditionsCacheService(
            IMemoryCache memoryCache,
            ILogger<EncounterConditionsCacheService> logger,
            IEncounterConditionsService encounterConditionsService)
        {
            _memoryCache                = memoryCache;
            _logger                     = logger;
            _encounterConditionsService = encounterConditionsService;
            _typeName                   = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _encounterConditionsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _encounterConditionsService.GetAll(limit, offset));

        public async Task<EncounterCondition> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _encounterConditionsService.Get(id));

        public async Task<EncounterCondition> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _encounterConditionsService.Get(name));
    }
}