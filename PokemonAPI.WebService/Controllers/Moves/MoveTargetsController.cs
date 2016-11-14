using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/move-targets")]
    public class MoveTargetsController : ApiController
    {
        private readonly IMoveTargetsCacheService _moveTargetsCacheService;

        public MoveTargetsController(IMoveTargetsCacheService moveTargetsCacheService)
        {
            _moveTargetsCacheService = moveTargetsCacheService;
        }

        // GET api/v1/move-targets
        // GET api/v1/move-targets?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _moveTargetsCacheService.Count();
            var controllerType = typeof(MoveTargetsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var moveTargets = await _moveTargetsCacheService.GetAll(limit, offset);
            if (moveTargets == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, moveTargets));
        }

        // GET api/v1/move-targets/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var berry = await _moveTargetsCacheService.Get(id);
            if (berry == null)
                return NotFound(id);

            return Ok(berry);
        }

        // GET api/v1/move-targets/specific-move
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var berry = await _moveTargetsCacheService.Get(name);
            if (berry == null)
                return NotFound(name);

            return Ok(berry);
        }
    }
}