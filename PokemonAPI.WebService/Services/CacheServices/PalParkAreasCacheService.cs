using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class PalParkAreasCacheService : IPalParkAreasCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<PalParkAreasCacheService> _logger;
        private readonly IPalParkAreasService _palParkAreasService;
        private readonly string _typeName;

        public PalParkAreasCacheService(
            IMemoryCache memoryCache,
            ILogger<PalParkAreasCacheService> logger,
            IPalParkAreasService palParkAreasService)
        {
            _memoryCache         = memoryCache;
            _logger              = logger;
            _palParkAreasService = palParkAreasService;
            _typeName            = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _palParkAreasService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _palParkAreasService.GetAll(limit, offset));

        public async Task<PalParkArea> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _palParkAreasService.Get(id));

        public async Task<PalParkArea> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _palParkAreasService.Get(name));
    }
}