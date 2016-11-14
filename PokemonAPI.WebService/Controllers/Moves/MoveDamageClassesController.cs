using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/move-damage-classes")]
    public class MoveDamageClassesController : ApiController
    {
        private readonly IMoveDamageClassesCacheService _moveDamageClassesCacheService;

        public MoveDamageClassesController(IMoveDamageClassesCacheService moveDamageClassesCacheService)
        {
            _moveDamageClassesCacheService = moveDamageClassesCacheService;
        }

        // GET api/v1/move-damage-classes
        // GET api/v1/move-damage-classes?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _moveDamageClassesCacheService.Count();
            var controllerType = typeof(MoveDamageClassesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var moveDamageClasses = await _moveDamageClassesCacheService.GetAll(limit, offset);
            if (moveDamageClasses == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, moveDamageClasses));
        }

        // GET api/v1/move-damage-classes/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var moveDamageClass = await _moveDamageClassesCacheService.Get(id);
            if (moveDamageClass == null)
                return NotFound(id);

            return Ok(moveDamageClass);
        }

        // GET api/v1/move-damage-classes/1
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var moveDamageClass = await _moveDamageClassesCacheService.Get(name);
            if (moveDamageClass == null)
                return NotFound(name);

            return Ok(moveDamageClass);
        }
    }
}