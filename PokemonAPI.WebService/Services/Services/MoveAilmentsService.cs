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
    public class MoveAilmentsService : IMoveAilmentsService
    {
        private readonly VeekunContext _context;

        public MoveAilmentsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.MoveMetaAilments.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveMetaAilments, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .MoveMetaAilments
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<MoveAilment> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<MoveAilment> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<MoveAilment> Get(Expression<Func<EFMoveMetaAilments, bool>> predicate)
        {
            var ailment = await _context
                .MoveMetaAilments
                .AsNoTracking()
                .Include(x => x.MoveMeta).ThenInclude(x => x.Move)
                .Include(x => x.MoveMetaAilmentNames).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (ailment == null)
                return null;

            return new MoveAilment
            {
                Id    = ailment.Id,
                Name  = ailment.Identifier,
                Moves = GetMoves(ailment),
                Names = GetNames(ailment)
            };
        }

        private static List<NamedAPIResource> GetMoves(EFMoveMetaAilments ailment)
        {
            return ailment
                .MoveMeta
                .Select(x => x.Move.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFMoveMetaAilments ailment)
        {
            return ailment
                .MoveMetaAilmentNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}