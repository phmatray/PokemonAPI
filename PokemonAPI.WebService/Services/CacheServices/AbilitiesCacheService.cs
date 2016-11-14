using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class AbilitiesCacheService : IAbilitiesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<AbilitiesCacheService> _logger;
        private readonly IAbilitiesService _abilitiesService;
        private readonly string _typeName;

        public AbilitiesCacheService(
            IMemoryCache memoryCache,
            ILogger<AbilitiesCacheService> logger,
            IAbilitiesService abilitiesService)
        {
            _memoryCache      = memoryCache;
            _logger           = logger;
            _abilitiesService = abilitiesService;
            _typeName         = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _abilitiesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _abilitiesService.GetAll(limit, offset));

        public async Task<Ability> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _abilitiesService.Get(id));

        public async Task<Ability> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _abilitiesService.Get(name));
    }
}