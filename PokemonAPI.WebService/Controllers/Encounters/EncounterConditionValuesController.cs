using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/encounter-condition-values")]
    public class EncounterConditionValuesController : ApiController
    {
        private readonly IEncounterConditionValuesCacheService _encounterConditionValuesCacheService;

        public EncounterConditionValuesController(IEncounterConditionValuesCacheService encounterConditionValuesCacheService)
        {
            _encounterConditionValuesCacheService = encounterConditionValuesCacheService;
        }

        // GET api/v1/encounter-condition-values
        // GET api/v1/encounter-condition-values?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _encounterConditionValuesCacheService.Count();
            var controllerType = typeof(EncounterConditionValuesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var encounterConditionValues = await _encounterConditionValuesCacheService.GetAll(limit, offset);
            if (encounterConditionValues == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, encounterConditionValues));
        }

        // GET api/v1/encounter-condition-values/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var encounterConditionValue = await _encounterConditionValuesCacheService.Get(id);
            if (encounterConditionValue == null)
                return NotFound(id);

            return Ok(encounterConditionValue);
        }

        // GET api/v1/encounter-condition-values/time-day
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var encounterConditionValue = await _encounterConditionValuesCacheService.Get(name);
            if (encounterConditionValue == null)
                return NotFound(name);

            return Ok(encounterConditionValue);
        }
    }
}