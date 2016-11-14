using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class BerryFlavorsCacheService : IBerryFlavorsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<BerryFlavorsCacheService> _logger;
        private readonly IBerryFlavorsService _berryFlavorsService;
        private readonly string _typeName;

        public BerryFlavorsCacheService(
            IMemoryCache memoryCache,
            ILogger<BerryFlavorsCacheService> logger,
            IBerryFlavorsService berryFlavorsService)
        {
            _memoryCache         = memoryCache;
            _logger              = logger;
            _berryFlavorsService = berryFlavorsService;
            _typeName            = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _berryFlavorsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _berryFlavorsService.GetAll(limit, offset));

        public async Task<BerryFlavor> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _berryFlavorsService.Get(id));

        public async Task<BerryFlavor> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _berryFlavorsService.Get(name));
    }
}