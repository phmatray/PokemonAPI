using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.Services
{
    public class ItemPocketsService : IItemPocketsService
    {
        private readonly VeekunContext _context;

        public ItemPocketsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.ItemPockets.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFItemPockets, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .ItemPockets
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<ItemPocket> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<ItemPocket> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<ItemPocket> Get(Expression<Func<EFItemPockets, bool>> predicate)
        {
            var itemPocket = await _context.ItemPockets
                .AsNoTracking()
                .Include(x => x.ItemCategories)
                .Include(x => x.ItemPocketNames).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (itemPocket == null)
                return null;

            return new ItemPocket
            {
                Id         = itemPocket.Id,
                Name       = itemPocket.Identifier,
                Categories = GetCategories(itemPocket),
                Names      = GetNames(itemPocket),
            };
        }

        private static List<NamedAPIResource> GetCategories(EFItemPockets itemPocket)
        {
            return itemPocket
                .ItemCategories
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFItemPockets itemPocket)
        {
            return itemPocket
                .ItemPocketNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}