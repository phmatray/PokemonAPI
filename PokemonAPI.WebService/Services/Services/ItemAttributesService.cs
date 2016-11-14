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
    public class ItemAttributesService : IItemAttributesService
    {
        private readonly VeekunContext _context;

        public ItemAttributesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.ItemFlags.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFItemFlags, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .ItemFlags
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<ItemAttribute> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<ItemAttribute> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<ItemAttribute> Get(Expression<Func<EFItemFlags, bool>> predicate)
        {
            var itemAttribute = await _context.ItemFlags
                .AsNoTracking()
                .Include(x => x.ItemFlagMap).ThenInclude(x => x.Item)
                .Include(x => x.ItemFlagProse).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (itemAttribute == null)
                return null;

            return new ItemAttribute
            {
                Id           = itemAttribute.Id,
                Name         = itemAttribute.Identifier,
                Items        = GetItems(itemAttribute),
                Names        = GetNames(itemAttribute),
                Descriptions = GetDescriptions(itemAttribute)
            };
        }

        private static List<NamedAPIResource> GetItems(EFItemFlags itemAttribute)
        {
            return itemAttribute
                .ItemFlagMap
                .Select(x => x.Item.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFItemFlags itemAttribute)
        {
            return itemAttribute
                .ItemFlagProse
                .Where(x => x.Name != null)
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<Description> GetDescriptions(EFItemFlags itemAttribute)
        {
            return itemAttribute
                .ItemFlagProse
                .Where(x => x.Description != null)
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}