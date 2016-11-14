using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/version-groups")]
    public class VersionGroupsController : ApiController
    {
        private readonly IVersionGroupsCacheService _versionGroupsCacheService;

        public VersionGroupsController(IVersionGroupsCacheService versionGroupsCacheService)
        {
            _versionGroupsCacheService = versionGroupsCacheService;
        }

        // GET api/v1/version-groups
        // GET api/v1/version-groups?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _versionGroupsCacheService.Count();
            var controllerType = typeof(VersionGroupsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var versionGroups = await _versionGroupsCacheService.GetAll(limit, offset);
            if (versionGroups == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, versionGroups));
        }

        // GET api/v1/version-groups/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var versionGroup = await _versionGroupsCacheService.Get(id);
            if (versionGroup == null)
                return NotFound(id);

            return Ok(versionGroup);
        }

        // GET api/v1/version-groups/red-blue
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var versionGroup = await _versionGroupsCacheService.Get(name);
            if (versionGroup == null)
                return NotFound(name);

            return Ok(versionGroup);
        }
    }
}