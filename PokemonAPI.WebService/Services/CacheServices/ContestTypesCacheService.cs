using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class ContestTypesCacheService : IContestTypesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<ContestTypesCacheService> _logger;
        private readonly IContestTypesService _contestTypesService;
        private readonly string _typeName;

        public ContestTypesCacheService(
            IMemoryCache memoryCache,
            ILogger<ContestTypesCacheService> logger,
            IContestTypesService contestTypesService)
        {
            _memoryCache         = memoryCache;
            _logger              = logger;
            _contestTypesService = contestTypesService;
            _typeName            = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _contestTypesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _contestTypesService.GetAll(limit, offset));

        public async Task<ContestType> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _contestTypesService.Get(id));

        public async Task<ContestType> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _contestTypesService.Get(name));
    }
}