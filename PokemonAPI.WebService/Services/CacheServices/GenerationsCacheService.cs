using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class GenerationsCacheService : IGenerationsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<GenerationsCacheService> _logger;
        private readonly IGenerationsService _generationsService;
        private readonly string _typeName;

        public GenerationsCacheService(
            IMemoryCache memoryCache,
            ILogger<GenerationsCacheService> logger,
            IGenerationsService generationsService)
        {
            _memoryCache        = memoryCache;
            _logger             = logger;
            _generationsService = generationsService;
            _typeName           = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _generationsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _generationsService.GetAll(limit, offset));

        public async Task<Generation> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _generationsService.Get(id));

        public async Task<Generation> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _generationsService.Get(name));
    }
}