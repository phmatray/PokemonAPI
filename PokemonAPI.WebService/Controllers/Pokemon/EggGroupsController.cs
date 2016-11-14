using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/egg-groups")]
    public class EggGroupsController : ApiController
    {
        private readonly IEggGroupsCacheService _eggGroupsCacheService;

        public EggGroupsController(IEggGroupsCacheService eggGroupsCacheService)
        {
            _eggGroupsCacheService = eggGroupsCacheService;
        }

        // GET api/v1/egggroups
        // GET api/v1/egggroups?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _eggGroupsCacheService.Count();
            var controllerType = typeof(EggGroupsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var eggGroups = await _eggGroupsCacheService.GetAll(limit, offset);
            if (eggGroups == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, eggGroups));
        }

        // GET api/v1/egggroups/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var eggGroup = await _eggGroupsCacheService.Get(id);
            if (eggGroup == null)
                return NotFound(id);

            return Ok(eggGroup);
        }

        // GET api/v1/egggroups/monster
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var eggGroup = await _eggGroupsCacheService.Get(name);
            if (eggGroup == null)
                return NotFound(name);

            return Ok(eggGroup);
        }
    }
}