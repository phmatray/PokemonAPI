using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class EggGroupsCacheService : IEggGroupsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<EggGroupsCacheService> _logger;
        private readonly IEggGroupsService _eggGroupsService;
        private readonly string _typeName;

        public EggGroupsCacheService(
            IMemoryCache memoryCache,
            ILogger<EggGroupsCacheService> logger,
            IEggGroupsService eggGroupsService)
        {
            _memoryCache      = memoryCache;
            _logger           = logger;
            _eggGroupsService = eggGroupsService;
            _typeName         = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _eggGroupsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _eggGroupsService.GetAll(limit, offset));

        public async Task<EggGroup> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _eggGroupsService.Get(id));

        public async Task<EggGroup> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _eggGroupsService.Get(name));
    }
}