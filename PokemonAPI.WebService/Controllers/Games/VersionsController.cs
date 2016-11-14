using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/versions")]
    public class VersionsController : ApiController
    {
        private readonly IVersionsCacheService _versionsCacheService;

        public VersionsController(IVersionsCacheService versionsCacheService)
        {
            _versionsCacheService = versionsCacheService;
        }

        // GET api/v1/versions
        // GET api/v1/versions?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _versionsCacheService.Count();
            var controllerType = typeof(VersionsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var versions = await _versionsCacheService.GetAll(limit, offset);
            if (versions == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, versions));
        }

        // GET api/v1/versions/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var version = await _versionsCacheService.Get(id);
            if (version == null)
                return NotFound(id);

            return Ok(version);
        }

        // GET api/v1/versions/red
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var version = await _versionsCacheService.Get(name);
            if (version == null)
                return NotFound(name);

            return Ok(version);
        }
    }
}