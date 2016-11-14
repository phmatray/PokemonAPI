using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class ItemCategoriesCacheService : IItemCategoriesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<ItemCategoriesCacheService> _logger;
        private readonly IItemCategoriesService _itemCategoriesService;
        private readonly string _typeName;

        public ItemCategoriesCacheService(
            IMemoryCache memoryCache,
            ILogger<ItemCategoriesCacheService> logger,
            IItemCategoriesService itemCategoriesService)
        {
            _memoryCache           = memoryCache;
            _logger                = logger;
            _itemCategoriesService = itemCategoriesService;
            _typeName              = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _itemCategoriesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _itemCategoriesService.GetAll(limit, offset));

        public async Task<ItemCategory> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _itemCategoriesService.Get(id));

        public async Task<ItemCategory> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _itemCategoriesService.Get(name));
    }
}