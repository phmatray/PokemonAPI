using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/genders")]
    public class GendersController : ApiController
    {
        private readonly IGendersCacheService _gendersCacheService;

        public GendersController(IGendersCacheService gendersCacheService)
        {
            _gendersCacheService = gendersCacheService;
        }

        // GET api/v1/genders
        // GET api/v1/genders?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _gendersCacheService.Count();
            var controllerType = typeof(GendersController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var genders = await _gendersCacheService.GetAll(limit, offset);
            if (genders == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, genders));
        }

        // GET api/v1/genders/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var gender = await _gendersCacheService.Get(id);
            if (gender == null)
                return NotFound(id);

            return Ok(gender);
        }

        // GET api/v1/genders/female
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var gender = await _gendersCacheService.Get(name);
            if (gender == null)
                return NotFound(name);

            return Ok(gender);
        }
    }
}