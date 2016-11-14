using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/move-ailments")]
    public class MoveAilmentsController : ApiController
    {
        private readonly IMoveAilmentsCacheService _moveAilmentsCacheService;

        public MoveAilmentsController(IMoveAilmentsCacheService moveAilmentsCacheService)
        {
            _moveAilmentsCacheService = moveAilmentsCacheService;
        }

        // GET api/v1/move-ailments
        // GET api/v1/move-ailments?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0) 
        {
            var count          = await _moveAilmentsCacheService.Count();
            var controllerType = typeof(MoveAilmentsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var moveAilments = await _moveAilmentsCacheService.GetAll(limit, offset);
            if (moveAilments == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, moveAilments));
        }

        // GET api/v1/move-ailments/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var moveAilment = await _moveAilmentsCacheService.Get(id);
            if (moveAilment == null)
                return NotFound(id);

            return Ok(moveAilment);
        }

        // GET api/v1/move-ailments/burn
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var moveAilment = await _moveAilmentsCacheService.Get(name);
            if (moveAilment == null)
                return NotFound(name);

            return Ok(moveAilment);
        }
    }
}