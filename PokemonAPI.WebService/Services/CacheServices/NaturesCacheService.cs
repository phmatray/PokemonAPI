using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class NaturesCacheService : INaturesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<NaturesCacheService> _logger;
        private readonly INaturesService _naturesService;
        private readonly string _typeName;

        public NaturesCacheService(
            IMemoryCache memoryCache,
            ILogger<NaturesCacheService> logger,
            INaturesService naturesService)
        {
            _memoryCache    = memoryCache;
            _logger         = logger;
            _naturesService = naturesService;
            _typeName       = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _naturesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _naturesService.GetAll(limit, offset));

        public async Task<Nature> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _naturesService.Get(id));

        public async Task<Nature> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _naturesService.Get(name));
    }
}