using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/generations")]
    public class GenerationsController : ApiController
    {
        private readonly IGenerationsCacheService _generationsCacheService;

        public GenerationsController(IGenerationsCacheService generationsCacheService)
        {
            _generationsCacheService = generationsCacheService;
        }

        // GET api/v1/generations
        // GET api/v1/generations?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _generationsCacheService.Count();
            var controllerType = typeof(GenerationsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var generations = await _generationsCacheService.GetAll(limit, offset);
            if (generations == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, generations));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="400">If the is is equals or lower than 0.</response>
        // GET api/v1/generations/1
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(int), 400)]
        public async Task<IActionResult> Get(int id)
        {
            var generation = await _generationsCacheService.Get(id);
            if (generation == null)
                return NotFound(id);

            return Ok(generation);
        }

        // GET api/v1/generations/generation-i
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var generation = await _generationsCacheService.Get(name);
            if (generation == null)
                return NotFound(name);

            return Ok(generation);
        }
        
    }
}