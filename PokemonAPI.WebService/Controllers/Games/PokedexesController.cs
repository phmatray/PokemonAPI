using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pokedexes")]
    public class PokedexesController : ApiController
    {
        private readonly IPokedexesCacheService _pokedexesCacheService;

        public PokedexesController(IPokedexesCacheService pokedexesCacheService)
        {
            _pokedexesCacheService = pokedexesCacheService;
        }

        // GET api/v1/pokedexes
        // GET api/v1/pokedexes?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _pokedexesCacheService.Count();
            var controllerType = typeof(PokedexesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var pokedexes = await _pokedexesCacheService.GetAll(limit, offset);
            if (pokedexes == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, pokedexes));
        }

        // GET api/v1/pokedexes/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var pokedex = await _pokedexesCacheService.Get(id);
            if (pokedex == null)
                return NotFound(id);

            return Ok(pokedex);
        }

        // GET api/v1/pokedexes/kanto
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var pokedex = await _pokedexesCacheService.Get(name);
            if (pokedex == null)
                return NotFound(name);

            return Ok(pokedex);
        }
    }
}