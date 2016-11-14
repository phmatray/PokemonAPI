using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/contest-types")]
    public class ContestTypesController : ApiController
    {
        private readonly IContestTypesCacheService _contestTypesCacheService;

        public ContestTypesController(IContestTypesCacheService contestTypesCacheService)
        {
            _contestTypesCacheService = contestTypesCacheService;
        }

        // GET api/v1/contest-types
        // GET api/v1/contest-types?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _contestTypesCacheService.Count();
            var controllerType = typeof(ContestTypesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var contestTypes = await _contestTypesCacheService.GetAll(limit, offset);
            if (contestTypes == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, contestTypes));
        }

        // GET api/v1/contest-types/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var contestType = await _contestTypesCacheService.Get(id);
            if (contestType == null)
                return NotFound(id);

            return Ok(contestType);
        }
    }
}