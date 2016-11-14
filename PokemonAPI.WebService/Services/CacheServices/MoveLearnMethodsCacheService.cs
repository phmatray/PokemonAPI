using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class MoveLearnMethodsCacheService : IMoveLearnMethodsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<MoveLearnMethodsCacheService> _logger;
        private readonly IMoveLearnMethodsService _moveLearnMethodsService;
        private readonly string _typeName;

        public MoveLearnMethodsCacheService(
            IMemoryCache memoryCache,
            ILogger<MoveLearnMethodsCacheService> logger,
            IMoveLearnMethodsService moveLearnMethodsService)
        {
            _memoryCache             = memoryCache;
            _logger                  = logger;
            _moveLearnMethodsService = moveLearnMethodsService;
            _typeName                = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _moveLearnMethodsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _moveLearnMethodsService.GetAll(limit, offset));

        public async Task<MoveLearnMethod> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _moveLearnMethodsService.Get(id));

        public async Task<MoveLearnMethod> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _moveLearnMethodsService.Get(name));
    }
}