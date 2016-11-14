using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pal-park-areas")]
    public class PalParkAreasController : ApiController
    {
        private readonly IPalParkAreasCacheService _palParkAreasCacheService;

        public PalParkAreasController(IPalParkAreasCacheService palParkAreasCacheService)
        {
            _palParkAreasCacheService = palParkAreasCacheService;
        }

        // GET api/v1/pal-park-areas
        // GET api/v1/pal-park-areas?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _palParkAreasCacheService.Count();
            var controllerType = typeof(PalParkAreasController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var palParkAreas = await _palParkAreasCacheService.GetAll(limit, offset);
            if (palParkAreas == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, palParkAreas));
        }

        // GET api/v1/pal-park-areas/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var palParkArea = await _palParkAreasCacheService.Get(id);
            if (palParkArea == null)
                return NotFound(id);

            return Ok(palParkArea);
        }

        // GET api/v1/pal-park-areas/forest
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var palParkArea = await _palParkAreasCacheService.Get(name);
            if (palParkArea == null)
                return NotFound(name);

            return Ok(palParkArea);
        }
    }
}