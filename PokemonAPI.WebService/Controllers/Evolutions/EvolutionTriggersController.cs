using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/evolution-triggers")]
    public class EvolutionTriggersController : ApiController
    {
        private readonly IEvolutionTriggersCacheService _evolutionTriggersCacheService;

        public EvolutionTriggersController(IEvolutionTriggersCacheService evolutionTriggersCacheService)
        {
            _evolutionTriggersCacheService = evolutionTriggersCacheService;
        }

        // GET api/v1/evolution-triggers
        // GET api/v1/evolution-triggers?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _evolutionTriggersCacheService.Count();
            var controllerType = typeof(EvolutionTriggersController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var evolutionTriggers = await _evolutionTriggersCacheService.GetAll(limit, offset);
            if (evolutionTriggers == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, evolutionTriggers));
        }

        // GET api/v1/evolution-triggers/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var evolutionTrigger = await _evolutionTriggersCacheService.Get(id);
            if (evolutionTrigger == null)
                return NotFound(id);

            return Ok(evolutionTrigger);
        }

        // GET api/v1/evolution-triggers/trade
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var evolutionTrigger = await _evolutionTriggersCacheService.Get(name);
            if (evolutionTrigger == null)
                return NotFound(name);

            return Ok(evolutionTrigger);
        }
    }
}