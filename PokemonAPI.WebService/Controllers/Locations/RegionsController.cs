using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/regions")]
    public class RegionsController : ApiController
    {
        private readonly IRegionsCacheService _regionsCacheService;

        public RegionsController(IRegionsCacheService regionsCacheService)
        {
            _regionsCacheService = regionsCacheService;
        }

        // GET api/v1/regions
        // GET api/v1/regions?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _regionsCacheService.Count();
            var controllerType = typeof(RegionsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var regions = await _regionsCacheService.GetAll(limit, offset);
            if (regions == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, regions));
        }

        // GET api/v1/regions/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var region = await _regionsCacheService.Get(id);
            if (region == null)
                return NotFound(id);

            return Ok(region);
        }

        // GET api/v1/regions/kanto
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var region = await _regionsCacheService.Get(name);
            if (region == null)
                return NotFound(name);

            return Ok(region);
        }
    }
}