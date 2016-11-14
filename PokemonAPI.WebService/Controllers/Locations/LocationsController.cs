using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/locations")]
    public class LocationsController : ApiController
    {
        private readonly ILocationsCacheService _locationsCacheService;

        public LocationsController(ILocationsCacheService locationsCacheService)
        {
            _locationsCacheService = locationsCacheService;
        }

        // GET api/v1/locations
        // GET api/v1/locations?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _locationsCacheService.Count();
            var controllerType = typeof(LocationsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var locations = await _locationsCacheService.GetAll(limit, offset);
            if (locations == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, locations));
        }

        // GET api/v1/locations/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var location = await _locationsCacheService.Get(id);
            if (location == null)
                return NotFound(id);

            return Ok(location);
        }

        // GET api/v1/locations/canalave-city
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var location = await _locationsCacheService.Get(name);
            if (location == null)
                return NotFound(name);

            return Ok(location);
        }
    }
}