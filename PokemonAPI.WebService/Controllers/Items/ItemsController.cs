using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/items")]
    public class ItemsController : ApiController
    {
        private readonly IItemsCacheService _itemsCacheService;

        public ItemsController(IItemsCacheService itemsCacheService)
        {
            _itemsCacheService = itemsCacheService;
        }

        // GET api/v1/items
        // GET api/v1/items?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _itemsCacheService.Count();
            var controllerType = typeof(ItemsController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var items = await _itemsCacheService.GetAll(limit, offset);
            if (items == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, items));
        }

        // GET api/v1/items/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _itemsCacheService.Get(id);
            if (item == null)
                return NotFound(id);

            return Ok(item);
        }

        // GET api/v1/items/1
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var item = await _itemsCacheService.Get(name);
            if (item == null)
                return NotFound(name);

            return Ok(item);
        }
    }
}