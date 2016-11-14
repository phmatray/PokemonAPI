using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class PokemonHabitatsCacheService : IPokemonHabitatsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<PokemonHabitatsCacheService> _logger;
        private readonly IPokemonHabitatsService _pokemonHabitatsService;
        private readonly string _typeName;

        public PokemonHabitatsCacheService(
            IMemoryCache memoryCache,
            ILogger<PokemonHabitatsCacheService> logger,
            IPokemonHabitatsService pokemonHabitatsService)
        {
            _memoryCache            = memoryCache;
            _logger                 = logger;
            _pokemonHabitatsService = pokemonHabitatsService;
            _typeName               = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _pokemonHabitatsService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _pokemonHabitatsService.GetAll(limit, offset));

        public async Task<PokemonHabitat> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _pokemonHabitatsService.Get(id));

        public async Task<PokemonHabitat> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _pokemonHabitatsService.Get(name));
    }
}