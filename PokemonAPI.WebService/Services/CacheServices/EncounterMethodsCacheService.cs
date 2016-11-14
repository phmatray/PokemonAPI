using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class EncounterMethodsCacheService : IEncounterMethodsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<EncounterMethodsCacheService> _logger;
        private readonly IEncounterMethodsService _encounterMethodsService;
        private readonly string _typeName;

        public EncounterMethodsCacheService(
            IMemoryCache memoryCache,
            ILogger<EncounterMethodsCacheService> logger,
            IEncounterMethodsService encounterMethodsService)
        {
            _memoryCache             = memoryCache;
            _logger                  = logger;
            _encounterMethodsService = encounterMethodsService;
            _typeName                = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _encounterMethodsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _encounterMethodsService.GetAll(limit, offset));

        public async Task<EncounterMethod> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _encounterMethodsService.Get(id));

        public async Task<EncounterMethod> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _encounterMethodsService.Get(name));
    }
}