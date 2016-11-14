using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class MoveAilmentsCacheService : IMoveAilmentsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<MoveAilmentsCacheService> _logger;
        private readonly IMoveAilmentsService _moveAilmentsService;
        private readonly string _typeName;

        public MoveAilmentsCacheService(
            IMemoryCache memoryCache,
            ILogger<MoveAilmentsCacheService> logger,
            IMoveAilmentsService moveAilmentsService)
        {
            _memoryCache         = memoryCache;
            _logger              = logger;
            _moveAilmentsService = moveAilmentsService;
            _typeName            = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _moveAilmentsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _moveAilmentsService.GetAll(limit, offset));

        public async Task<MoveAilment> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _moveAilmentsService.Get(id));

        public async Task<MoveAilment> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _moveAilmentsService.Get(name));
    }
}