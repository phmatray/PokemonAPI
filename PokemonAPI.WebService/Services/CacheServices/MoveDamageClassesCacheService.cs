using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class MoveDamageClassesCacheService : IMoveDamageClassesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<MoveDamageClassesCacheService> _logger;
        private readonly IMoveDamageClassesService _moveDamageClassesService;
        private readonly string _typeName;

        public MoveDamageClassesCacheService(
            IMemoryCache memoryCache,
            ILogger<MoveDamageClassesCacheService> logger,
            IMoveDamageClassesService moveDamageClassesService)
        {
            _memoryCache              = memoryCache;
            _logger                   = logger;
            _moveDamageClassesService = moveDamageClassesService;
            _typeName                 = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _moveDamageClassesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _moveDamageClassesService.GetAll(limit, offset));

        public async Task<MoveDamageClass> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _moveDamageClassesService.Get(id));

        public async Task<MoveDamageClass> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _moveDamageClassesService.Get(name));
    }
}