using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class EvolutionTriggersCacheService : IEvolutionTriggersCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<EvolutionTriggersCacheService> _logger;
        private readonly IEvolutionTriggersService _evolutionTriggersService;
        private readonly string _typeName;

        public EvolutionTriggersCacheService(
            IMemoryCache memoryCache,
            ILogger<EvolutionTriggersCacheService> logger,
            IEvolutionTriggersService evolutionTriggersService)
        {
            _memoryCache              = memoryCache;
            _logger                   = logger;
            _evolutionTriggersService = evolutionTriggersService;
            _typeName                 = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _evolutionTriggersService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _evolutionTriggersService.GetAll(limit, offset));

        public async Task<EvolutionTrigger> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _evolutionTriggersService.Get(id));

        public async Task<EvolutionTrigger> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _evolutionTriggersService.Get(name));
    }
}