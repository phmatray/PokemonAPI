using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class MoveCategoriesCacheService : IMoveCategoriesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<MoveCategoriesCacheService> _logger;
        private readonly IMoveCategoriesService _moveCategoriesService;
        private readonly string _typeName;

        public MoveCategoriesCacheService(
            IMemoryCache memoryCache,
            ILogger<MoveCategoriesCacheService> logger,
            IMoveCategoriesService moveCategoriesService)
        {
            _memoryCache             = memoryCache;
            _logger                  = logger;
            _moveCategoriesService = moveCategoriesService;
            _typeName                = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _moveCategoriesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _moveCategoriesService.GetAll(limit, offset));

        public async Task<MoveCategory> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _moveCategoriesService.Get(id));

        public async Task<MoveCategory> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _moveCategoriesService.Get(name));
    }
}