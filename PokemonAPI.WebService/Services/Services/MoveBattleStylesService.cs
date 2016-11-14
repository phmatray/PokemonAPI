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
    public class MoveBattleStylesService : IMoveBattleStylesService
    {
        private readonly VeekunContext _context;

        public MoveBattleStylesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.MoveBattleStyles.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveBattleStyles, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .MoveBattleStyles
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<MoveBattleStyle> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<MoveBattleStyle> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<MoveBattleStyle> Get(Expression<Func<EFMoveBattleStyles, bool>> predicate)
        {
            var moveBattleStyle = await _context
                .MoveBattleStyles
                .AsNoTracking()
                .Include(x => x.MoveBattleStyleProse).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (moveBattleStyle == null)
                return null;

            return new MoveBattleStyle
            {
                Id    = moveBattleStyle.Id,
                Name  = moveBattleStyle.Identifier,
                Names = GetNames(moveBattleStyle),
            };
        }

        private static List<Name> GetNames(EFMoveBattleStyles moveBattleStyle)
        {
            return moveBattleStyle
                .MoveBattleStyleProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}