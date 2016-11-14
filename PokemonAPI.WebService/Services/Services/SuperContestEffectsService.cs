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
    public class SuperContestEffectsService : ISuperContestEffectsService
    {
        private readonly VeekunContext _context;

        public SuperContestEffectsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.SuperContestEffects.CountAsync();
        }

        public async Task<List<APIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<APIResource>> GetAll(Expression<Func<EFSuperContestEffects, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .SuperContestEffects
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<SuperContestEffect> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<SuperContestEffect> Get(Expression<Func<EFSuperContestEffects, bool>> predicate)
        {
            var superContestEffect = await _context.SuperContestEffects
                .AsNoTracking()
                .Include(x => x.SuperContestEffectProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.Moves)
                .FirstOrDefaultAsync(predicate);

            if (superContestEffect == null)
                return null;
             
            return new SuperContestEffect
            {
                Id                = superContestEffect.Id,
                Appeal            = superContestEffect.Appeal,
                FlavorTextEntries = GetFlavorTextEntries(superContestEffect),
                Moves             = GetMoves(superContestEffect)
            };
        }

        private static List<FlavorText> GetFlavorTextEntries(EFSuperContestEffects superContestEffect)
        {
            return superContestEffect
                .SuperContestEffectProse
                .Select(x => new FlavorText(x.FlavorText, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetMoves(EFSuperContestEffects superContestEffect)
        {
            return superContestEffect
                .Moves
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}