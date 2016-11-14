using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/stats")]
    public class StatsController : ApiController
    {
        private readonly IStatsCacheService _statsCacheService;

        public StatsController(IStatsCacheService statsCacheService)
        {
            _statsCacheService = statsCacheService;
        }

        // GET api/v1/stats
        // GET api/v1/stats?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _statsCacheService.Count();
            var controllerType = typeof(StatsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var stats = await _statsCacheService.GetAll(limit, offset);
            if (stats == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, stats));
        }

        // GET api/v1/stats/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var stat = await _statsCacheService.Get(id);
            if (stat == null)
                return NotFound(id);

            return Ok(stat);
        }

        // GET api/v1/stats/attack
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var stat = await _statsCacheService.Get(name);
            if (stat == null)
                return NotFound(name);

            return Ok(stat);
        }
    }
}