using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface INaturesCacheService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<Nature> Get(int id);
        Task<Nature> Get(string name);
    }
}