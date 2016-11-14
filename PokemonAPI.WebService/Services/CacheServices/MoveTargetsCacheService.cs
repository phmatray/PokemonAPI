using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class MoveTargetsCacheService : IMoveTargetsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<MoveTargetsCacheService> _logger;
        private readonly IMoveTargetsService _moveTargetsService;
        private readonly string _typeName;

        public MoveTargetsCacheService(
            IMemoryCache memoryCache,
            ILogger<MoveTargetsCacheService> logger,
            IMoveTargetsService moveTargetsService)
        {
            _memoryCache        = memoryCache;
            _logger             = logger;
            _moveTargetsService = moveTargetsService;
            _typeName           = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _moveTargetsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _moveTargetsService.GetAll(limit, offset));

        public async Task<MoveTarget> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _moveTargetsService.Get(id));

        public async Task<MoveTarget> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _moveTargetsService.Get(name));
    }
}