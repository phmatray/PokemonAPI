using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pokemon-shapes")]
    public class PokemonShapesController : ApiController
    {
        private readonly IPokemonShapesCacheService _pokemonShapesCacheService;

        public PokemonShapesController(IPokemonShapesCacheService pokemonShapesCacheService)
        {
            _pokemonShapesCacheService = pokemonShapesCacheService;
        }

        // GET api/v1/pokemon-shapes
        // GET api/v1/pokemon-shapes?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _pokemonShapesCacheService.Count();
            var controllerType = typeof(PokemonShapesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var pokemonShapes = await _pokemonShapesCacheService.GetAll(limit, offset);
            if (pokemonShapes == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, pokemonShapes));
        }

        // GET api/v1/pokemon-shapes/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var pokemonShape = await _pokemonShapesCacheService.Get(id);
            if (pokemonShape == null)
                return NotFound(id);

            return Ok(pokemonShape);
        }

        // GET api/v1/pokemon-shapes/1
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var pokemonShape = await _pokemonShapesCacheService.Get(name);
            if (pokemonShape == null)
                return NotFound(name);

            return Ok(pokemonShape);
        }
    }
}