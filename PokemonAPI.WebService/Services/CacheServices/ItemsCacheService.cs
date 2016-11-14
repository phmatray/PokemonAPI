using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class ItemsCacheService : IItemsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<ItemsCacheService> _logger;
        private readonly IItemsService _itemsService;
        private readonly string _typeName;

        public ItemsCacheService(
            IMemoryCache memoryCache,
            ILogger<ItemsCacheService> logger,
            IItemsService itemsService)
        {
            _memoryCache           = memoryCache;
            _logger                = logger;
            _itemsService = itemsService;
            _typeName              = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _itemsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _itemsService.GetAll(limit, offset));

        public async Task<Item> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _itemsService.Get(id));

        public async Task<Item> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _itemsService.Get(name));
    }
}