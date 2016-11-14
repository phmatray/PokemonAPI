using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/location-areas")]
    public class LocationAreasController : ApiController
    {
        private readonly ILocationAreasCacheService _locationAreasCacheService;

        public LocationAreasController(ILocationAreasCacheService locationAreasCacheService)
        {
            _locationAreasCacheService = locationAreasCacheService;
        }

        // GET api/v1/location-areas
        // GET api/v1/location-areas?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _locationAreasCacheService.Count();
            var controllerType = typeof(LocationAreasController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var locationAreas = await _locationAreasCacheService.GetAll(limit, offset);
            if (locationAreas == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, locationAreas));
        }

        // GET api/v1/location-areas/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var locationArea = await _locationAreasCacheService.Get(id);
            if (locationArea == null)
                return NotFound(id);

            return Ok(locationArea);
        }

        // GET api/v1/location-areas/1
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var locationArea = await _locationAreasCacheService.Get(name);
            if (locationArea == null)
                return NotFound(name);

            return Ok(locationArea);
        }
    }
}