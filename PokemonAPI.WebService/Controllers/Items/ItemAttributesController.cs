using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/item-attributes")]
    public class ItemAttributesController : ApiController
    {
        private readonly IItemAttributesCacheService _itemAttributesCacheService;

        public ItemAttributesController(IItemAttributesCacheService itemAttributesCacheService)
        {
            _itemAttributesCacheService = itemAttributesCacheService;
        }

        // GET api/v1/item-attributes
        // GET api/v1/item-attributes?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _itemAttributesCacheService.Count();
            var controllerType = typeof(ItemAttributesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var itemAttributes = await _itemAttributesCacheService.GetAll(limit, offset);
            if (itemAttributes == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, itemAttributes));
        }

        // GET api/v1/item-attributes/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var itemAttribute = await _itemAttributesCacheService.Get(id);
            if (itemAttribute == null)
                return NotFound(id);

            return Ok(itemAttribute);
        }

        // GET api/v1/item-attributes/countable
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var itemAttribute = await _itemAttributesCacheService.Get(name);
            if (itemAttribute == null)
                return NotFound(name);

            return Ok(itemAttribute);
        }
    }
}