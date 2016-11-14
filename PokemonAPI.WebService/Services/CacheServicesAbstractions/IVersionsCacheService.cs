using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using Version = PokemonAPI.Models.Rsc.Version;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface IVersionsCacheService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<Version> Get(int id);
        Task<Version> Get(string name);
    }
}