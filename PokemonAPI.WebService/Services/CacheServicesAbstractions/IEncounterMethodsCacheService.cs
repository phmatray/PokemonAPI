using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface IEncounterMethodsCacheService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<EncounterMethod> Get(int id);
        Task<EncounterMethod> Get(string name);
    }
}