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
    public class ContestEffectsService : IContestEffectsService
    {
        private readonly VeekunContext _context;

        public ContestEffectsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.ContestEffects.CountAsync();
        }

        public async Task<List<APIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<APIResource>> GetAll(Expression<Func<EFContestEffects, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .ContestEffects
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<ContestEffect> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<ContestEffect> Get(Expression<Func<EFContestEffects, bool>> predicate)
        {
            var contestEffect = await _context.ContestEffects
                .AsNoTracking()
                .Include(x => x.ContestEffectProse).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (contestEffect == null)
                return null;

            return new ContestEffect
            {
                Id                = contestEffect.Id,
                Appeal            = contestEffect.Appeal,
                Jam               = contestEffect.Jam,
                EffectEntries     = GetEffectEntries(contestEffect),
                FlavorTextEntries = GetFlavorTextEntries(contestEffect)
            };
        }

        private static List<Effect> GetEffectEntries(EFContestEffects contestEffect)
        {
            return contestEffect
                .ContestEffectProse
                .Select(x => new Effect(x.Effect, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<FlavorText> GetFlavorTextEntries(EFContestEffects contestEffect)
        {
            return contestEffect
                .ContestEffectProse
                .Select(x => new FlavorText(x.FlavorText, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}