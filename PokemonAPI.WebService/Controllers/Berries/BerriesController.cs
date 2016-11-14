using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/berries")]
    public class BerriesController : ApiController
    {
        private readonly IBerriesCacheService _berriesService;

        public BerriesController(IBerriesCacheService berriesService)
        {
            _berriesService = berriesService;
        }

        // GET api/v1/berries
        // GET api/v1/berries?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _berriesService.Count();
            var controllerType = typeof(BerriesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var berries = await _berriesService.GetAll(limit, offset);
            if (berries == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, berries));
        }

        // GET api/v1/berries/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var berry = await _berriesService.Get(id);
            if (berry == null)
                return NotFound(id);

            return Ok(berry);
        }

        // GET api/v1/berries/oran
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var berry = await _berriesService.Get(name);
            if (berry == null)
                return NotFound(name);

            return Ok(berry);
        }
    }
}