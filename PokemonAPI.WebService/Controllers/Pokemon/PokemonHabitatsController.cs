using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pokemon-habitats")]
    public class PokemonHabitatsController : ApiController
    {
        private readonly IPokemonHabitatsCacheService _pokemonHabitatsCacheService;

        public PokemonHabitatsController(IPokemonHabitatsCacheService pokemonHabitatsCacheService)
        {
            _pokemonHabitatsCacheService = pokemonHabitatsCacheService;
        }

        // GET api/v1/pokemon-habitats
        // GET api/v1/pokemon-habitats?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _pokemonHabitatsCacheService.Count();
            var controllerType = typeof(PokemonHabitatsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var pokemonHabitats = await _pokemonHabitatsCacheService.GetAll(limit, offset);
            if (pokemonHabitats == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, pokemonHabitats));
        }

        // GET api/v1/pokemon-habitats/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var pokemonHabitat = await _pokemonHabitatsCacheService.Get(id);
            if (pokemonHabitat == null)
                return NotFound(id);

            return Ok(pokemonHabitat);
        }

        // GET api/v1/pokemon-habitats/cave
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var pokemonHabitat = await _pokemonHabitatsCacheService.Get(name);
            if (pokemonHabitat == null)
                return NotFound(name);

            return Ok(pokemonHabitat);
        }
    }
}