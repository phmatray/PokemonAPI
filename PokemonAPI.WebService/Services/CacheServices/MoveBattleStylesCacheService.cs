using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class MoveBattleStylesCacheService : IMoveBattleStylesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<MoveBattleStylesCacheService> _logger;
        private readonly IMoveBattleStylesService _moveBattleStylesService;
        private readonly string _typeName;

        public MoveBattleStylesCacheService(
            IMemoryCache memoryCache,
            ILogger<MoveBattleStylesCacheService> logger,
            IMoveBattleStylesService moveBattleStylesService)
        {
            _memoryCache             = memoryCache;
            _logger                  = logger;
            _moveBattleStylesService = moveBattleStylesService;
            _typeName                = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _moveBattleStylesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _moveBattleStylesService.GetAll(limit, offset));

        public async Task<MoveBattleStyle> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _moveBattleStylesService.Get(id));

        public async Task<MoveBattleStyle> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _moveBattleStylesService.Get(name));
    }
}