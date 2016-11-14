using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/natures")]
    public class NaturesController : ApiController
    {
        private readonly INaturesCacheService _naturesCacheService;

        public NaturesController(INaturesCacheService naturesCacheService)
        {
            _naturesCacheService = naturesCacheService;
        }

        // GET api/v1/natures
        // GET api/v1/natures?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 25, int offset = 0)
        {
            var count          = await _naturesCacheService.Count();
            var controllerType = typeof(NaturesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var natures = await _naturesCacheService.GetAll(limit, offset);
            if (natures == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, natures));
        }

        // GET api/v1/natures/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var berry = await _naturesCacheService.Get(id);
            if (berry == null)
                return NotFound(id);

            return Ok(berry);
        }

        // GET api/v1/natures/hardy
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var berry = await _naturesCacheService.Get(name);
            if (berry == null)
                return NotFound(name);

            return Ok(berry);
        }
    }
}