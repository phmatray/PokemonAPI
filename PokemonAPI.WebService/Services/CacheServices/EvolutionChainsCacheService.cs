using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class EvolutionChainsCacheService : IEvolutionChainsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<EvolutionChainsCacheService> _logger;
        private readonly IEvolutionChainsService _evolutionChainsService;
        private readonly string _typeName;

        public EvolutionChainsCacheService(
            IMemoryCache memoryCache,
            ILogger<EvolutionChainsCacheService> logger,
            IEvolutionChainsService evolutionChainsService)
        {
            _memoryCache            = memoryCache;
            _logger                 = logger;
            _evolutionChainsService = evolutionChainsService;
            _typeName               = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _evolutionChainsService.Count());

        public async Task<List<APIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _evolutionChainsService.GetAll(limit, offset));

        public async Task<EvolutionChain> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _evolutionChainsService.Get(id));
    }
}