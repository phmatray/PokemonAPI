using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/move-learn-methods")]
    public class MoveLearnMethodsController : ApiController
    {
        private readonly IMoveLearnMethodsCacheService _moveLearnMethodsCacheService;

        public MoveLearnMethodsController(IMoveLearnMethodsCacheService moveLearnMethodsCacheService)
        {
            _moveLearnMethodsCacheService = moveLearnMethodsCacheService;
        }

        // GET api/v1/move-learn-methods
        // GET api/v1/move-learn-methods?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _moveLearnMethodsCacheService.Count();
            var controllerType = typeof(MoveLearnMethodsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var moveLearnMethods = await _moveLearnMethodsCacheService.GetAll(limit, offset);
            if (moveLearnMethods == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, moveLearnMethods));
        }

        // GET api/v1/move-learn-methods/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var moveLearnMethod = await _moveLearnMethodsCacheService.Get(id);
            if (moveLearnMethod == null)
                return NotFound(id);

            return Ok(moveLearnMethod);
        }

        // GET api/v1/move-learn-methods/1
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var moveLearnMethod = await _moveLearnMethodsCacheService.Get(name);
            if (moveLearnMethod == null)
                return NotFound(name);

            return Ok(moveLearnMethod);
        }
    }
}