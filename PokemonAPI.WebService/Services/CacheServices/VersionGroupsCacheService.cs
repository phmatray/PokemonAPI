using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class VersionGroupsCacheService : IVersionGroupsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<VersionGroupsCacheService> _logger;
        private readonly IVersionGroupsService _versionGroupsService;
        private readonly string _typeName;

        public VersionGroupsCacheService(
            IMemoryCache memoryCache,
            ILogger<VersionGroupsCacheService> logger,
            IVersionGroupsService versionGroupsService)
        {
            _memoryCache          = memoryCache;
            _logger               = logger;
            _versionGroupsService = versionGroupsService;
            _typeName             = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _versionGroupsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _versionGroupsService.GetAll(limit, offset));

        public async Task<VersionGroup> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _versionGroupsService.Get(id));

        public async Task<VersionGroup> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _versionGroupsService.Get(name));
    }
}