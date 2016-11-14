using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/moves")]
    public class MovesController : ApiController
    {
        private readonly IMovesCacheService _movesCacheService;

        public MovesController(IMovesCacheService movesCacheService)
        {
            _movesCacheService = movesCacheService;
        }

        // GET api/v1/moves
        // GET api/v1/moves?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _movesCacheService.Count();
            var controllerType = typeof(MovesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var moves = await _movesCacheService.GetAll(limit, offset);
            if (moves == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, moves));
        }

        // GET api/v1/moves/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var move = await _movesCacheService.Get(id);
            if (move == null)
                return NotFound(id);

            return Ok(move);
        }

        // GET api/v1/moves/karate-chop
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var move = await _movesCacheService.Get(name);
            if (move == null)
                return NotFound(name);

            return Ok(move);
        }
    }
}