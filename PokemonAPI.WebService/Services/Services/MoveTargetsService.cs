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
    public class MoveTargetsService : IMoveTargetsService
    {
        private readonly VeekunContext _context;

        public MoveTargetsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.MoveTargets.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveTargets, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .MoveTargets
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<MoveTarget> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<MoveTarget> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<MoveTarget> Get(Expression<Func<EFMoveTargets, bool>> predicate)
        {
            var moveTarget = await _context
                .MoveTargets
                .AsNoTracking()
                .Include(x => x.MoveTargetProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.Moves)
                .FirstOrDefaultAsync(predicate);

            if (moveTarget == null)
                return null;

            return new MoveTarget
            {
                Id = moveTarget.Id,
                Name = moveTarget.Identifier,
                Descriptions = GetDescriptions(moveTarget),
                Moves = GetMoves(moveTarget),
                Names = GetNames(moveTarget)
            };
        }

        private static List<Description> GetDescriptions(EFMoveTargets moveTarget)
        {
            return moveTarget
                .MoveTargetProse
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetMoves(EFMoveTargets moveTarget)
        {
            return moveTarget
                .Moves
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFMoveTargets moveTarget)
        {
            return moveTarget
                .MoveTargetProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}