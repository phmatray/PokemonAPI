using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface IBerryFirmnessesCacheService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<BerryFirmness> Get(int id);
        Task<BerryFirmness> Get(string name);
    }
}