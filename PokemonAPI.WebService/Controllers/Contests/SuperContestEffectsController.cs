using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/super-contest-effects")]
    public class SuperContestEffectsController : ApiController
    {
        private readonly ISuperContestEffectsCacheService _superContestEffectsCacheService;

        public SuperContestEffectsController(ISuperContestEffectsCacheService superContestEffectsCacheService)
        {
            _superContestEffectsCacheService = superContestEffectsCacheService;
        }

        // GET api/v1/super-contest-effects
        // GET api/v1/super-contest-effects?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _superContestEffectsCacheService.Count();
            var controllerType = typeof(SuperContestEffectsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var superContestEffects = await _superContestEffectsCacheService.GetAll(limit, offset);
            if (superContestEffects == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new APIResourceList(count, previous, next, superContestEffects));
        }

        // GET api/v1/super-contest-effects/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var superContestEffect = await _superContestEffectsCacheService.Get(id);
            if (superContestEffect == null)
                return NotFound(id);

            return Ok(superContestEffect);
        }
    }
}