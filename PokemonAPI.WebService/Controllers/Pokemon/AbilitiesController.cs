using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/abilities")]
    public class AbilitiesController : ApiController
    {
        private readonly IAbilitiesCacheService _abilitiesCacheService;

        public AbilitiesController(IAbilitiesCacheService abilitiesCacheService)
        {
            _abilitiesCacheService = abilitiesCacheService;
        }

        // GET api/v1/abilities
        // GET api/v1/abilities?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _abilitiesCacheService.Count();
            var controllerType = typeof(AbilitiesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var abilities = await _abilitiesCacheService.GetAll(limit, offset);
            if (abilities == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, abilities));
        }

        // GET api/v1/abilities/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var ability = await _abilitiesCacheService.Get(id);
            if (ability == null)
                return NotFound(id);

            return Ok(ability);
        }

        // GET api/v1/abilities/stench
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var ability = await _abilitiesCacheService.Get(name);
            if (ability == null)
                return NotFound(name);

            return Ok(ability);
        }
    }
}