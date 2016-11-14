using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/item-categories")]
    public class ItemCategoriesController : ApiController
    {
        private readonly IItemCategoriesCacheService _itemCategoriesCacheService;

        public ItemCategoriesController(IItemCategoriesCacheService itemCategoriesCacheService)
        {
            _itemCategoriesCacheService = itemCategoriesCacheService;
        }

        // GET api/v1/item-categories
        // GET api/v1/item-categories?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _itemCategoriesCacheService.Count();
            var controllerType = typeof(ItemCategoriesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var itemCategories = await _itemCategoriesCacheService.GetAll(limit, offset);
            if (itemCategories == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, itemCategories));
        }

        // GET api/v1/item-categories/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var itemCategory = await _itemCategoriesCacheService.Get(id);
            if (itemCategory == null)
                return NotFound(id);

            return Ok(itemCategory);
        }

        // GET api/v1/item-categories/medicine
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var itemCategory = await _itemCategoriesCacheService.Get(name);
            if (itemCategory == null)
                return NotFound(name);

            return Ok(itemCategory);
        }
    }
}