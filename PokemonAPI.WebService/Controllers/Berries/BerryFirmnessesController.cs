using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/berry-firmnesses")]
    public class BerryFirmnessesController : ApiController
    {
        private readonly IBerryFirmnessesCacheService _berryFirmnessesCacheService;

        public BerryFirmnessesController(IBerryFirmnessesCacheService berryFirmnessesCacheService)
        {
            _berryFirmnessesCacheService = berryFirmnessesCacheService;
        }

        // GET api/v1/berry-firmnesses
        // GET api/v1/berry-firmnesses?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _berryFirmnessesCacheService.Count();
            var controllerType = typeof(BerryFirmnessesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var berryFirmnesses = await _berryFirmnessesCacheService.GetAll(limit, offset);
            if (berryFirmnesses == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, berryFirmnesses));
        }

        // GET api/v1/berry-firmnesses/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var berryFirmness = await _berryFirmnessesCacheService.Get(id);
            if (berryFirmness == null)
                return NotFound(id);

            return Ok(berryFirmness);
        }

        // GET api/v1/berry-firmnesses/soft
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var berryFirmness = await _berryFirmnessesCacheService.Get(name);
            if (berryFirmness == null)
                return NotFound(name);

            return Ok(berryFirmness);
        }
    }
}