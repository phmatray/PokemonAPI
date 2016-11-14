using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pokemon-colors")]
    public class PokemonColorsController : ApiController
    {
        private readonly IPokemonColorsCacheService _pokemonColorsCacheService;

        public PokemonColorsController(IPokemonColorsCacheService pokemonColorsCacheService)
        {
            _pokemonColorsCacheService = pokemonColorsCacheService;
        }

        // GET api/v1/pokemoncolors
        // GET api/v1/pokemoncolors?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _pokemonColorsCacheService.Count();
            var controllerType = typeof(PokemonColorsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var pokemonColors = await _pokemonColorsCacheService.GetAll(limit, offset);
            if (pokemonColors == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, pokemonColors));
        }

        // GET api/v1/pokemoncolors/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var pokemonColor = await _pokemonColorsCacheService.Get(id);
            if (pokemonColor == null)
                return NotFound(id);

            return Ok(pokemonColor);
        }

        // GET api/v1/pokemoncolors/black
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var pokemonColor = await _pokemonColorsCacheService.Get(name);
            if (pokemonColor == null)
                return NotFound(name);

            return Ok(pokemonColor);
        }
    }
}