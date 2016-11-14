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
    public class ItemCategoriesService : IItemCategoriesService
    {
        private readonly VeekunContext _context;

        public ItemCategoriesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.ItemCategories.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFItemCategories, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .ItemCategories
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<ItemCategory> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<ItemCategory> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<ItemCategory> Get(Expression<Func<EFItemCategories, bool>> predicate)
        {
            var itemCategory = await _context.ItemCategories
                .AsNoTracking()
                .Include(x => x.Items)
                .Include(x => x.ItemCategoryProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.Pocket)
                .FirstOrDefaultAsync(predicate);

            if (itemCategory == null)
                return null;

            return new ItemCategory
            {
                Id     = itemCategory.Id,
                Name   = itemCategory.Identifier,
                Items  = GetItems(itemCategory),
                Names  = GetNames(itemCategory),
                Pocket = GetPocket(itemCategory)
            };
        }

        private static List<NamedAPIResource> GetItems(EFItemCategories itemCategory)
        {
            return itemCategory
                .Items
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFItemCategories itemCategory)
        {
            return itemCategory
                .ItemCategoryProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static NamedAPIResource GetPocket(EFItemCategories itemCategory)
        {
            return itemCategory
                .Pocket?
                .ToNamedApiResource();
        }
    }
}