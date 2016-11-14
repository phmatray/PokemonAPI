using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.WebService.Core;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/characteristics")]
    public class CharacteristicsController : ApiController
    {
        private readonly ICharacteristicsCacheService _characteristicsCacheService;

        public CharacteristicsController(ICharacteristicsCacheService characteristicsCacheService)
        {
            _characteristicsCacheService = characteristicsCacheService;
        }

        // GET api/v1/characteristics
        // GET api/v1/characteristics?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 30, int offset = 0)
        {
            var count          = await _characteristicsCacheService.Count();
            var controllerType = typeof(CharacteristicsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var characteristics = await _characteristicsCacheService.GetAll(limit, offset);
            if (characteristics == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new APIResourceList(count, previous, next, characteristics));
        }

        // GET api/v1/characteristics/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var characteristic = await _characteristicsCacheService.Get(id);
            if (characteristic == null)
                return NotFound(id);

            return Ok(characteristic);
        }
    }
}