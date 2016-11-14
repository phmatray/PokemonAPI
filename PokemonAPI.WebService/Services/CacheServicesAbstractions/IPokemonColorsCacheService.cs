using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface IPokemonColorsCacheService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<PokemonColor> Get(int id);
        Task<PokemonColor> Get(string name);
    }
}