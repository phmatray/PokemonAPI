using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/move-categories")]
    public class MoveCategoriesController : ApiController
    {
        private readonly IMoveCategoriesCacheService _moveCategoriesCacheService;

        public MoveCategoriesController(IMoveCategoriesCacheService moveCategoriesCacheService)
        {
            _moveCategoriesCacheService = moveCategoriesCacheService;
        }

        // GET api/v1/move-categories
        // GET api/v1/move-categories?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _moveCategoriesCacheService.Count();
            var controllerType = typeof(MoveCategoriesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var moveCategories = await _moveCategoriesCacheService.GetAll(limit, offset);
            if (moveCategories == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, moveCategories));
        }

        // GET api/v1/move-categories/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var moveCategory = await _moveCategoriesCacheService.Get(id);
            if (moveCategory == null)
                return NotFound(id);

            return Ok(moveCategory);
        }

        // GET api/v1/move-categories/heal
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var moveCategory = await _moveCategoriesCacheService.Get(name);
            if (moveCategory == null)
                return NotFound(name);

            return Ok(moveCategory);
        }
    }
}