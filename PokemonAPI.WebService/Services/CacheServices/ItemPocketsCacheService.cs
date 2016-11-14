using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class ItemPocketsCacheService : IItemPocketsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<ItemPocketsCacheService> _logger;
        private readonly IItemPocketsService _itemPocketsService;
        private readonly string _typeName;

        public ItemPocketsCacheService(
            IMemoryCache memoryCache,
            ILogger<ItemPocketsCacheService> logger,
            IItemPocketsService itemPocketsService)
        {
            _memoryCache        = memoryCache;
            _logger             = logger;
            _itemPocketsService = itemPocketsService;
            _typeName           = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _itemPocketsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _itemPocketsService.GetAll(limit, offset));

        public async Task<ItemPocket> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _itemPocketsService.Get(id));

        public async Task<ItemPocket> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _itemPocketsService.Get(name));
    }
}