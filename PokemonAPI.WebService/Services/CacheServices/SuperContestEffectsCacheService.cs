using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class SuperContestEffectsCacheService : ISuperContestEffectsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<SuperContestEffectsCacheService> _logger;
        private readonly ISuperContestEffectsService _superContestEffectsService;
        private readonly string _typeName;

        public SuperContestEffectsCacheService(
            IMemoryCache memoryCache,
            ILogger<SuperContestEffectsCacheService> logger,
            ISuperContestEffectsService superContestEffectsService)
        {
            _memoryCache                = memoryCache;
            _logger                     = logger;
            _superContestEffectsService = superContestEffectsService;
            _typeName                   = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _superContestEffectsService.Count());

        public async Task<List<APIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _superContestEffectsService.GetAll(limit, offset));

        public async Task<SuperContestEffect> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _superContestEffectsService.Get(id));
    }
}