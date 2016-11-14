using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class MovesCacheService : IMovesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<MovesCacheService> _logger;
        private readonly IMovesService _movesService;
        private readonly string _typeName;

        public MovesCacheService(
            IMemoryCache memoryCache,
            ILogger<MovesCacheService> logger,
            IMovesService movesService)
        {
            _memoryCache  = memoryCache;
            _logger       = logger;
            _movesService = movesService;
            _typeName     = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _movesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _movesService.GetAll(limit, offset));

        public async Task<Move> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _movesService.Get(id));

        public async Task<Move> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _movesService.Get(name));
    }
}