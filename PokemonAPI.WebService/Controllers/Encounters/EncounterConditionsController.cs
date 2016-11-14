using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/encounter-conditions")]
    public class EncounterConditionsController : ApiController
    {
        private readonly IEncounterConditionsCacheService _encounterConditionsCacheService;

        public EncounterConditionsController(IEncounterConditionsCacheService encounterConditionsCacheService)
        {
            _encounterConditionsCacheService = encounterConditionsCacheService;
        }

        // GET api/v1/encounter-conditions
        // GET api/v1/encounter-conditions?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _encounterConditionsCacheService.Count();
            var controllerType = typeof(EncounterConditionsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var encounterConditions = await _encounterConditionsCacheService.GetAll(limit, offset);
            if (encounterConditions == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, encounterConditions));
        }

        // GET api/v1/encounter-conditions/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var berryFirmness = await _encounterConditionsCacheService.Get(id);
            if (berryFirmness == null)
                return NotFound(id);

            return Ok(berryFirmness);
        }

        // GET api/v1/encounter-conditions/radar
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var berryFirmness = await _encounterConditionsCacheService.Get(name);
            if (berryFirmness == null)
                return NotFound(name);

            return Ok(berryFirmness);
        }
    }
}