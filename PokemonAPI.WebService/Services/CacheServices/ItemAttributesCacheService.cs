using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class ItemAttributesCacheService : IItemAttributesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<ItemAttributesCacheService> _logger;
        private readonly IItemAttributesService _itemAttributesService;
        private readonly string _typeName;

        public ItemAttributesCacheService(
            IMemoryCache memoryCache,
            ILogger<ItemAttributesCacheService> logger,
            IItemAttributesService itemAttributesService)
        {
            _memoryCache           = memoryCache;
            _logger                = logger;
            _itemAttributesService = itemAttributesService;
            _typeName              = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _itemAttributesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _itemAttributesService.GetAll(limit, offset));

        public async Task<ItemAttribute> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _itemAttributesService.Get(id));

        public async Task<ItemAttribute> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _itemAttributesService.Get(name));
    }
}