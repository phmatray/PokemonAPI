using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class LocationsCacheService : ILocationsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<LocationsCacheService> _logger;
        private readonly ILocationsService _locationsService;
        private readonly string _typeName;

        public LocationsCacheService(
            IMemoryCache memoryCache,
            ILogger<LocationsCacheService> logger,
            ILocationsService locationsService)
        {
            _memoryCache      = memoryCache;
            _logger           = logger;
            _locationsService = locationsService;
            _typeName         = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _locationsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _locationsService.GetAll(limit, offset));

        public async Task<Location> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _locationsService.Get(id));

        public async Task<Location> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _locationsService.Get(name));
    }
}