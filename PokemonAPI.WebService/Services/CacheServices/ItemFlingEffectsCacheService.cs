using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class ItemFlingEffectsCacheService : IItemFlingEffectsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<ItemFlingEffectsCacheService> _logger;
        private readonly IItemFlingEffectsService _itemFlingEffectsService;
        private readonly string _typeName;

        public ItemFlingEffectsCacheService(
            IMemoryCache memoryCache,
            ILogger<ItemFlingEffectsCacheService> logger,
            IItemFlingEffectsService itemFlingEffectsService)
        {
            _memoryCache             = memoryCache;
            _logger                  = logger;
            _itemFlingEffectsService = itemFlingEffectsService;
            _typeName                = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _itemFlingEffectsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _itemFlingEffectsService.GetAll(limit, offset));

        public async Task<ItemFlingEffect> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _itemFlingEffectsService.Get(id));

        public async Task<ItemFlingEffect> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _itemFlingEffectsService.Get(name));
    }
}