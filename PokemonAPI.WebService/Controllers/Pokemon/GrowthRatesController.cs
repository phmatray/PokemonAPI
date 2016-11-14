using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/growth-rates")]
    public class GrowthRatesController : ApiController
    {
        private readonly IGrowthRatesCacheService _growthRatesCacheService;

        public GrowthRatesController(IGrowthRatesCacheService growthRatesCacheService)
        {
            _growthRatesCacheService = growthRatesCacheService;
        }

        // GET api/v1/growthrates
        // GET api/v1/growthrates?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _growthRatesCacheService.Count();
            var controllerType = typeof(GrowthRatesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var growthRates = await _growthRatesCacheService.GetAll(limit, offset);
            if (growthRates == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, growthRates));
        }

        // GET api/v1/growthrates/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var growthRate = await _growthRatesCacheService.Get(id);
            if (growthRate == null)
                return NotFound(id);

            return Ok(growthRate);
        }

        // GET api/v1/growthrates/slow
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var growthRate = await _growthRatesCacheService.Get(name);
            if (growthRate == null)
                return NotFound(name);

            return Ok(growthRate);
        }
    }
}