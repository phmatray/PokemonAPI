using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/machines")]
    public class MachinesController : ApiController
    {
        private readonly IMachinesCacheService _machinesCacheService;

        public MachinesController(IMachinesCacheService machinesCacheService)
        {
            _machinesCacheService = machinesCacheService;
        }

        // GET api/v1/machines
        // GET api/v1/machines?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _machinesCacheService.Count();
            var controllerType = typeof(MachinesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var berries = await _machinesCacheService.GetAll(limit, offset);
            if (berries == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new APIResourceList(count, previous, next, berries));
        }

        // GET api/v1/machines?machineNumber=1&versionGroupId=1
        [HttpGet("{machineNumber:int}/{versionGroupId:int}")]
        public async Task<IActionResult> Get(int machineNumber, int versionGroupId)
        {
            var berry = await _machinesCacheService.Get(machineNumber, versionGroupId);
            if (berry == null)
                return NotFound($"{machineNumber}/{versionGroupId}");

            return Ok(berry);
        }
    }
}