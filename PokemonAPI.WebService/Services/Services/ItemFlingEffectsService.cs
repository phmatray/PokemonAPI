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
    public class ItemFlingEffectsService : IItemFlingEffectsService
    {
        private readonly VeekunContext _context;

        public ItemFlingEffectsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.ItemFlingEffects.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFItemFlingEffects, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .ItemFlingEffects
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<ItemFlingEffect> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<ItemFlingEffect> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<ItemFlingEffect> Get(Expression<Func<EFItemFlingEffects, bool>> predicate)
        {
            var itemFlingEffect = await _context.ItemFlingEffects
                .AsNoTracking()
                .Include(x => x.ItemFlingEffectProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.Items)
                .FirstOrDefaultAsync(predicate);

            if (itemFlingEffect == null)
                return null;

            return new ItemFlingEffect
            {
                Id            = itemFlingEffect.Id,
                Name          = itemFlingEffect.Identifier,
                EffectEntries = GetEffectEntries(itemFlingEffect),
                Items         = GetItems(itemFlingEffect),
            };
        }

        private static List<Effect> GetEffectEntries(EFItemFlingEffects itemFlingEffect)
        {
            return itemFlingEffect
                .ItemFlingEffectProse
                .Select(x => new Effect(x.Effect, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetItems(EFItemFlingEffects itemFlingEffect)
        {
            return itemFlingEffect
                .Items
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}