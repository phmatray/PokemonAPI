using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class VersionsCacheService : IVersionsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<VersionsCacheService> _logger;
        private readonly IVersionsService _versionsService;
        private readonly string _typeName;

        public VersionsCacheService(
            IMemoryCache memoryCache,
            ILogger<VersionsCacheService> logger,
            IVersionsService versionsService)
        {
            _memoryCache     = memoryCache;
            _logger          = logger;
            _versionsService = versionsService;
            _typeName        = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _versionsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _versionsService.GetAll(limit, offset));

        public async Task<Version> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _versionsService.Get(id));

        public async Task<Version> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _versionsService.Get(name));
    }
}