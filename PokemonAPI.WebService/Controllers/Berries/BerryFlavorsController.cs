using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/berry-flavors")]
    public class BerryFlavorsController : ApiController
    {
        private readonly IBerryFlavorsCacheService _berryFlavorsCacheService;

        public BerryFlavorsController(IBerryFlavorsCacheService berryFlavorsCacheService)
        {
            _berryFlavorsCacheService = berryFlavorsCacheService;
        }

        // GET api/v1/berry-flavors
        // GET api/v1/berry-flavors?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _berryFlavorsCacheService.Count();
            var controllerType = typeof(BerryFlavorsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var berryFlavors = await _berryFlavorsCacheService.GetAll(limit, offset);
            if (berryFlavors == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, berryFlavors));
        }

        // GET api/v1/berry-flavors/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var berryFirmness = await _berryFlavorsCacheService.Get(id);
            if (berryFirmness == null)
                return NotFound(id);

            return Ok(berryFirmness);
        }

        // GET api/v1/berry-flavors/spicy
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var berryFirmness = await _berryFlavorsCacheService.Get(name);
            if (berryFirmness == null)
                return NotFound(name);

            return Ok(berryFirmness);
        }
    }
}