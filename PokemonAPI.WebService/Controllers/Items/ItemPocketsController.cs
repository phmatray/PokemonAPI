using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/item-pockets")]
    public class ItemPocketsController : ApiController
    {
        private readonly IItemPocketsCacheService _itemPocketsCacheService;

        public ItemPocketsController(IItemPocketsCacheService itemPocketsCacheService)
        {
            _itemPocketsCacheService = itemPocketsCacheService;
        }

        // GET api/v1/item-pockets
        // GET api/v1/item-pockets?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _itemPocketsCacheService.Count();
            var controllerType = typeof(ItemPocketsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var itemPockets = await _itemPocketsCacheService.GetAll(limit, offset);
            if (itemPockets == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, itemPockets));
        }

        // GET api/v1/item-pockets/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var itemPocket = await _itemPocketsCacheService.Get(id);
            if (itemPocket == null)
                return NotFound(id);

            return Ok(itemPocket);
        }

        // GET api/v1/item-pockets/medicine
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var itemPocket = await _itemPocketsCacheService.Get(name);
            if (itemPocket == null)
                return NotFound(name);

            return Ok(itemPocket);
        }
    }
}