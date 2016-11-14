using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pokemons")]
    public class PokemonsController : ApiController
    {
        private readonly IPokemonsCacheService _pokemonsService;

        public PokemonsController(IPokemonsCacheService pokemonsService)
        {
            _pokemonsService = pokemonsService;
        }

        // GET api/v1/pokemons
        // GET api/v1/pokemons?limit=0&offset=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _pokemonsService.Count();
            var controllerType = typeof(PokemonsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var pokemons = await _pokemonsService.GetAll(limit, offset);
            if (pokemons == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, pokemons));
        }

        // GET api/v1/pokemons/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var pokemon = await _pokemonsService.Get(id);
            if (pokemon == null)
                return NotFound(id);

            return Ok(pokemon);
        }

        // GET api/v1/pokemons/pikachu
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var pokemon = await _pokemonsService.Get(name);
            if (pokemon == null)
                return NotFound(name);

            return Ok(pokemon);
        }

        // GET api/v1/pokemons/1/encounters
        [HttpGet("{id:int}/encounters")]
        public async Task<IActionResult> GetEncounters(int id)
        {
            var encounters = await _pokemonsService.GetEncounters(id);
            if (encounters == null)
                return NotFound(id);

            return Ok(encounters);
        }

        // GET api/v1/pokemons/pikachu/encounters
        [HttpGet("{name}/encounters")]
        public async Task<IActionResult> GetEncounters(string name)
        {
            var encounters = await _pokemonsService.GetEncounters(name);
            if (encounters == null)
                return NotFound(name);

            return Ok(encounters);
        }
    }
}