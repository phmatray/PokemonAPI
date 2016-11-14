using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/move-battle-styles")]
    public class MoveBattleStylesController : ApiController
    {
        private readonly IMoveBattleStylesCacheService _moveBattleStylesCacheService;

        public MoveBattleStylesController(IMoveBattleStylesCacheService moveBattleStylesCacheService)
        {
            _moveBattleStylesCacheService = moveBattleStylesCacheService;
        }

        // GET api/v1/move-battle-styles
        // GET api/v1/move-battle-styles?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _moveBattleStylesCacheService.Count();
            var controllerType = typeof(MoveBattleStylesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var moveBattleStyles = await _moveBattleStylesCacheService.GetAll(limit, offset);
            if (moveBattleStyles == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, moveBattleStyles));
        }

        // GET api/v1/move-battle-styles/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var moveBattleStyle = await _moveBattleStylesCacheService.Get(id);
            if (moveBattleStyle == null)
                return NotFound(id);

            return Ok(moveBattleStyle);
        }

        // GET api/v1/move-battle-styles/1
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var moveBattleStyle = await _moveBattleStylesCacheService.Get(name);
            if (moveBattleStyle == null)
                return NotFound(name);

            return Ok(moveBattleStyle);
        }
    }
}