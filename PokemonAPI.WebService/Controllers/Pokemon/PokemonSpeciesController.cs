using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pokemon-species")]
    public class PokemonSpeciesController : ApiController
    {
        private readonly IPokemonSpeciesCacheService _pokemonSpeciesCacheService;

        public PokemonSpeciesController(IPokemonSpeciesCacheService pokemonSpeciesCacheService)
        {
            _pokemonSpeciesCacheService = pokemonSpeciesCacheService;
        }

        // GET api/v1/pokemonspecies
        // GET api/v1/pokemonspecies?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _pokemonSpeciesCacheService.Count();
            var controllerType = typeof(PokemonSpeciesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var pokemonSpecies = await _pokemonSpeciesCacheService.GetAll(limit, offset);
            if (pokemonSpecies == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, pokemonSpecies));
        }

        // GET api/v1/pokemonspecies/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var pokemonSpecies = await _pokemonSpeciesCacheService.Get(id);
            if (pokemonSpecies == null)
                return NotFound(id);

            return Ok(pokemonSpecies);
        }

        // GET api/v1/pokemonspecies/bulbasaur
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var pokemonSpecies = await _pokemonSpeciesCacheService.Get(name);
            if (pokemonSpecies == null)
                return NotFound(name);

            return Ok(pokemonSpecies);
        }
    }
}