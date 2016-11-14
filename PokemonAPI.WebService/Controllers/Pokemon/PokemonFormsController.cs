using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pokemon-forms")]
    public class PokemonFormsController : ApiController
    {
        private readonly IPokemonFormsCacheService _pokemonFormsCacheService;

        public PokemonFormsController(IPokemonFormsCacheService pokemonFormsCacheService)
        {
            _pokemonFormsCacheService = pokemonFormsCacheService;
        }

        // GET api/v1/pokemon-forms
        // GET api/v1/pokemon-forms?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _pokemonFormsCacheService.Count();
            var controllerType = typeof(PokemonFormsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var pokemonForms = await _pokemonFormsCacheService.GetAll(limit, offset);
            if (pokemonForms == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, pokemonForms));
        }

        // GET api/v1/pokemon-forms/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var pokemonForm = await _pokemonFormsCacheService.Get(id);
            if (pokemonForm == null)
                return NotFound(id);

            return Ok(pokemonForm);
        }

        // GET api/v1/pokemon-forms/bulbasaur
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var pokemonForm = await _pokemonFormsCacheService.Get(name);
            if (pokemonForm == null)
                return NotFound(name);

            return Ok(pokemonForm);
        }
    }
}