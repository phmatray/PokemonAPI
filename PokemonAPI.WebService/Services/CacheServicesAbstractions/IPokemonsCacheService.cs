using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface IPokemonsCacheService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<Pokemon> Get(int id);
        Task<Pokemon> Get(string name);
        Task<List<LocationAreaEncounter>> GetEncounters(int pokemonId);
        Task<List<LocationAreaEncounter>> GetEncounters(string pokemonName);
    }
}