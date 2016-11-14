using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/contest-effects")]
    public class ContestEffectsController : ApiController
    {
        private readonly IContestEffectsCacheService _contestEffectsCacheService;

        public ContestEffectsController(IContestEffectsCacheService contestEffectsCacheService)
        {
            _contestEffectsCacheService = contestEffectsCacheService;
        }

        // GET api/v1/contest-effects
        // GET api/v1/contest-effects?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _contestEffectsCacheService.Count();
            var controllerType = typeof(ContestEffectsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var contestEffects = await _contestEffectsCacheService.GetAll(limit, offset);
            if (contestEffects == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new APIResourceList(count, previous, next, contestEffects));
        }

        // GET api/v1/contest-effects/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var contestEffect = await _contestEffectsCacheService.Get(id);
            if (contestEffect == null)
                return NotFound(id);

            return Ok(contestEffect);
        }
    }
}