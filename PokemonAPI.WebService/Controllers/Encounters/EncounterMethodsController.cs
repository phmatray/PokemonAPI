using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/encounter-methods")]
    public class EncounterMethodsController : ApiController
    {
        private readonly IEncounterMethodsCacheService _encounterMethodsCacheService;

        public EncounterMethodsController(IEncounterMethodsCacheService encounterMethodsCacheService)
        {
            _encounterMethodsCacheService = encounterMethodsCacheService;
        }

        // GET api/v1/encounter-methods
        // GET api/v1/encounter-methods?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _encounterMethodsCacheService.Count();
            var controllerType = typeof(EncounterMethodsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var encounterMethods = await _encounterMethodsCacheService.GetAll(limit, offset);
            if (encounterMethods == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, encounterMethods));
        }

        // GET api/v1/encounter-methods/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var encounterMethod = await _encounterMethodsCacheService.Get(id);
            if (encounterMethod == null)
                return NotFound(id);

            return Ok(encounterMethod);
        }

        // GET api/v1/encounter-methods/1
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var encounterMethod = await _encounterMethodsCacheService.Get(name);
            if (encounterMethod == null)
                return NotFound(name);

            return Ok(encounterMethod);
        }
    }
}