using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class BerryFirmnessesCacheService : IBerryFirmnessesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<BerryFirmnessesCacheService> _logger;
        private readonly IBerryFirmnessesService _berryFirmnessesService;
        private readonly string _typeName;

        public BerryFirmnessesCacheService(
            IMemoryCache memoryCache,
            ILogger<BerryFirmnessesCacheService> logger,
            IBerryFirmnessesService berryFirmnessesService)
        {
            _memoryCache            = memoryCache;
            _logger                 = logger;
            _berryFirmnessesService = berryFirmnessesService;
            _typeName               = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _berryFirmnessesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _berryFirmnessesService.GetAll(limit, offset));

        public async Task<BerryFirmness> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _berryFirmnessesService.Get(id));

        public async Task<BerryFirmness> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _berryFirmnessesService.Get(name));
    }
}