using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/pokeathlon-stats")]
    public class PokeathlonStatsController : ApiController
    {
        private readonly IPokeathlonStatsCacheService _pokeathlonStatsCacheService;

        public PokeathlonStatsController(IPokeathlonStatsCacheService pokeathlonStatsCacheService)
        {
            _pokeathlonStatsCacheService = pokeathlonStatsCacheService;
        }

        // GET api/v1/pokeathlon-stats
        // GET api/v1/pokeathlon-stats?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _pokeathlonStatsCacheService.Count();
            var controllerType = typeof(PokeathlonStatsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var pokeathlonStats = await _pokeathlonStatsCacheService.GetAll(limit, offset);
            if (pokeathlonStats == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, pokeathlonStats));
        }

        // GET api/v1/pokeathlon-stats/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var pokeathlonStat = await _pokeathlonStatsCacheService.Get(id);
            if (pokeathlonStat == null)
                return NotFound(id);

            return Ok(pokeathlonStat);
        }

        // GET api/v1/pokeathlon-stats/speed
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var pokeathlonStat = await _pokeathlonStatsCacheService.Get(name);
            if (pokeathlonStat == null)
                return NotFound(name);

            return Ok(pokeathlonStat);
        }
    }
}