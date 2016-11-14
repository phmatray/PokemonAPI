using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;

namespace PokemonAPI.WebService.Services.CacheServicesAbstractions
{
    public interface IMachinesCacheService
    {
        Task<int> Count();
        Task<List<APIResource>> GetAll(int limit, int offset);
        Task<Machine> Get(int machineNumber, int versionGroupId);
    }
}