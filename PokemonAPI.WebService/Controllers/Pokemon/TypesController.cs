using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/types")]
    public class TypesController : ApiController
    {
        private readonly ITypesCacheService _typesCacheService;

        public TypesController(ITypesCacheService typesCacheService)
        {
            _typesCacheService = typesCacheService;
        }

        // GET api/v1/types
        // GET api/v1/types?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _typesCacheService.Count();
            var controllerType = typeof(TypesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var types = await _typesCacheService.GetAll(limit, offset);
            if (types == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, types));
        }

        // GET api/v1/types/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var type = await _typesCacheService.Get(id);
            if (type == null)
                return NotFound(id);

            return Ok(type);
        }

        // GET api/v1/types/normal
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var type = await _typesCacheService.Get(name);
            if (type == null)
                return NotFound(name);

            return Ok(type);
        }
    }
}