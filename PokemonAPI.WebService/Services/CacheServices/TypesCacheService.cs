using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class TypesCacheService : ITypesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<TypesCacheService> _logger;
        private readonly ITypesService _typesService;
        private readonly string _typeName;

        public TypesCacheService(
            IMemoryCache memoryCache,
            ILogger<TypesCacheService> logger,
            ITypesService typesService)
        {
            _memoryCache  = memoryCache;
            _logger       = logger;
            _typesService = typesService;
            _typeName     = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _typesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _typesService.GetAll(limit, offset));

        public async Task<Type> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _typesService.Get(id));

        public async Task<Type> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _typesService.Get(name));
    }
}