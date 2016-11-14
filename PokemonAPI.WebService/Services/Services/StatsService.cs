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
    
    public class StatsService : IStatsService
    {
        private readonly VeekunContext _context;

        public StatsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Stats.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFStats, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Stats
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Stat> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Stat> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Stat> Get(Expression<Func<EFStats, bool>> predicate)
        {
            var stat = await _context
                .Stats
                .AsNoTracking()
                .Include(x => x.MoveMetaStatChanges).ThenInclude(x => x.Move)
                .Include(x => x.NaturesIncreasedStat)
                .Include(x => x.NaturesDecreasedStat)
                .Include(x => x.Characteristics)
                .Include(x => x.DamageClass)
                .Include(x => x.StatNames).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (stat == null)
                return null;

            return new Stat
            {
                Id               = stat.Id,
                Name             = stat.Identifier,
                GameIndex        = stat.GameIndex,
                IsBattleOnly     = stat.IsBattleOnly,
                AffectingMoves   = GetAffectingMoves(stat),
                AffectingNatures = GetAffectingNatures(stat),
                Characteristics  = GetCharacteristics(stat),
                MoveDamageClass  = GetMoveDamageClass(stat),
                Names            = GetNames(stat)
            };
        }

        private static MoveStatAffectSets GetAffectingMoves(EFStats stat)
        {
            var moveMetaStatChanges = stat
                .MoveMetaStatChanges
                .Select(x => new MoveStatAffect(x.Change, x.Move.ToNamedApiResource()))
                .ToList();

            return new MoveStatAffectSets
            {
                Increase = moveMetaStatChanges
                    .Where(x => x.Change > 0)
                    .ToList(),
                Decrease = moveMetaStatChanges
                    .Where(x => x.Change < 0)
                    .ToList()
            };
        }

        private static NatureStatAffectSets GetAffectingNatures(EFStats stat)
        {
            return new NatureStatAffectSets
            {
                Increase = stat
                    .NaturesIncreasedStat
                    .Where(x => x.DecreasedStatId != stat.Id)
                    .Select(x => x.ToNamedApiResource())
                    .ToList(),
                Decrease = stat
                    .NaturesDecreasedStat
                    .Where(x => x.IncreasedStatId != stat.Id)
                    .Select(x => x.ToNamedApiResource())
                    .ToList()
            };
        }

        private static List<APIResource> GetCharacteristics(EFStats stat)
        {
            return stat
                .Characteristics
                .Select(x => x.ToApiResource())
                .ToList();
        }

        private static NamedAPIResource GetMoveDamageClass(EFStats stat)
        {
            return stat
                .DamageClass?
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFStats stat)
        {
            return stat
                .StatNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}