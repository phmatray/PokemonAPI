using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/item-fling-effects")]
    public class ItemFlingEffectsController : ApiController
    {
        private readonly IItemFlingEffectsCacheService _itemFlingEffectsCacheService;

        public ItemFlingEffectsController(IItemFlingEffectsCacheService itemFlingEffectsCacheService)
        {
            _itemFlingEffectsCacheService = itemFlingEffectsCacheService;
        }

        // GET api/v1/item-fling-effects
        // GET api/v1/item-fling-effects?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _itemFlingEffectsCacheService.Count();
            var controllerType = typeof(ItemFlingEffectsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var itemFlingEffects = await _itemFlingEffectsCacheService.GetAll(limit, offset);
            if (itemFlingEffects == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, itemFlingEffects));
        }

        // GET api/v1/item-fling-effects/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var itemFlingEffect = await _itemFlingEffectsCacheService.Get(id);
            if (itemFlingEffect == null)
                return NotFound(id);

            return Ok(itemFlingEffect);
        }

        // GET api/v1/item-fling-effects/1
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var itemFlingEffect = await _itemFlingEffectsCacheService.Get(name);
            if (itemFlingEffect == null)
                return NotFound(name);

            return Ok(itemFlingEffect);
        }
    }
}