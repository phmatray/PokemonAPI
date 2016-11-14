using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/evolution-chains")]
    public class EvolutionChainsController : ApiController
    {
        private readonly IEvolutionChainsCacheService _evolutionChainsCacheService;

        public EvolutionChainsController(IEvolutionChainsCacheService evolutionChainsCacheService)
        {
            _evolutionChainsCacheService = evolutionChainsCacheService;
        }

        // GET api/v1/evolution-chains
        // GET api/v1/evolution-chains?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _evolutionChainsCacheService.Count();
            var controllerType = typeof(EvolutionChainsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var evolutionChains = await _evolutionChainsCacheService.GetAll(limit, offset);
            if (evolutionChains == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new APIResourceList(count, previous, next, evolutionChains));
        }

        // GET api/v1/evolution-chains/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var evolutionChain = await _evolutionChainsCacheService.Get(id);
            if (evolutionChain == null)
                return NotFound(id);

            return Ok(evolutionChain);
        }
    }
}