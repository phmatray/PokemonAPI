using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class GendersCacheService : IGendersCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<GendersCacheService> _logger;
        private readonly IGendersService _gendersService;
        private readonly string _typeName;

        public GendersCacheService(
            IMemoryCache memoryCache,
            ILogger<GendersCacheService> logger,
            IGendersService gendersService)
        {
            _memoryCache    = memoryCache;
            _logger         = logger;
            _gendersService = gendersService;
            _typeName       = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _gendersService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _gendersService.GetAll(limit, offset));

        public async Task<Gender> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _gendersService.Get(id));

        public async Task<Gender> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _gendersService.Get(name));
    }
}