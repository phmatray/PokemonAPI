using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class LanguagesCacheService : ILanguagesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<LanguagesCacheService> _logger;
        private readonly ILanguagesService _languagesService;
        private readonly string _typeName;

        public LanguagesCacheService(
            IMemoryCache memoryCache,
            ILogger<LanguagesCacheService> logger,
            ILanguagesService languagesService)
        {
            _memoryCache      = memoryCache;
            _logger           = logger;
            _languagesService = languagesService;
            _typeName         = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _languagesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _languagesService.GetAll(limit, offset));

        public async Task<Language> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _languagesService.Get(id));

        public async Task<Language> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _languagesService.Get(name));
    }
}