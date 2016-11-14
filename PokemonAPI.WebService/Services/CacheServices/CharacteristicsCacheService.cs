using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class CharacteristicsCacheService : ICharacteristicsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<CharacteristicsCacheService> _logger;
        private readonly ICharacteristicsService _characteristicsService;
        private readonly string _typeName;

        public CharacteristicsCacheService(
            IMemoryCache memoryCache,
            ILogger<CharacteristicsCacheService> logger,
            ICharacteristicsService characteristicsService)
        {
            _memoryCache            = memoryCache;
            _logger                 = logger;
            _characteristicsService = characteristicsService;
            _typeName               = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _characteristicsService.Count());

        public async Task<List<APIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _characteristicsService.GetAll(limit, offset));

        public async Task<Characteristic> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _characteristicsService.Get(id));
    }
}