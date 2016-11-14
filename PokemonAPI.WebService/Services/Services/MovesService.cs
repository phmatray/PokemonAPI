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
    public class MovesService : IMovesService
    {
        private readonly VeekunContext _context;

        public MovesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Moves.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoves, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Moves
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Move> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Move> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Move> Get(Expression<Func<EFMoves, bool>> predicate)
        {
            var move = await _context
                .Moves
                .AsNoTracking()
                .Include(x => x.ContestCombosFirstMove).ThenInclude(x => x.SecondMove)
                .Include(x => x.ContestCombosSecondMove).ThenInclude(x => x.FirstMove)
                .Include(x => x.SuperContestCombosFirstMove).ThenInclude(x => x.SecondMove)
                .Include(x => x.SuperContestCombosSecondMove).ThenInclude(x => x.FirstMove)
                .Include(x => x.Effect).ThenInclude(x => x.MoveEffectProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.Effect).ThenInclude(x => x.MoveEffectChangelog).ThenInclude(x => x.MoveEffectChangelogProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.Effect).ThenInclude(x => x.MoveEffectChangelog).ThenInclude(x => x.ChangedInVersionGroup)
                .Include(x => x.MoveFlavorText).ThenInclude(x => x.Language)
                .Include(x => x.MoveFlavorText).ThenInclude(x => x.VersionGroup)
                .Include(x => x.Machines).ThenInclude(x => x.VersionGroup)
                .Include(x => x.MoveMeta).ThenInclude(x => x.MetaAilment)
                .Include(x => x.MoveMeta).ThenInclude(x => x.MetaCategory)
                .Include(x => x.MoveNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.MoveChangelog).ThenInclude(x => x.Type)
                .Include(x => x.MoveChangelog).ThenInclude(x => x.ChangedInVersionGroup)
                .Include(x => x.MoveMetaStatChanges).ThenInclude(x => x.Stat)
                .Include(x => x.ContestType)
                .Include(x => x.ContestEffect)
                .Include(x => x.DamageClass)
                .Include(x => x.Generation)
                .Include(x => x.SuperContestEffect)
                .Include(x => x.Target)
                .Include(x => x.Type)
                .FirstOrDefaultAsync(predicate);

            if (move == null)
                return null;

            return new Move
            {
                Id                 = move.Id,
                Name               = move.Identifier,
                Accuracy           = move.Accuracy,
                EffectChance       = move.EffectChance,
                Pp                 = move.Pp,
                Priority           = move.Priority,
                Power              = move.Power,
                ContestCombos      = GetContestCombos(move),
                ContestType        = GetContestType(move),
                ContestEffect      = GetContestEffect(move),
                DamageClass        = GetDamageClass(move),
                EffectEntries      = GetEffectEntries(move),
                EffectChanges      = GetEffectChanges(move),
                FlavorTextEntries  = GetFlavorTextEntries(move),
                Generation         = GetGeneration(move),
                Machines           = GetMachines(move),
                Meta               = GetMeta(move),
                Names              = GetNames(move),
                PastValues         = GetPastValues(move),
                StatChanges        = GetStatChanges(move),
                SuperContestEffect = GetSuperContestEffect(move),
                Target             = GetTarget(move),
                Type               = GetType(move)
            };
        }

        private static ContestComboSets GetContestCombos(EFMoves move)
        {
            var normalUseBefore = move
                .ContestCombosFirstMove
                .Select(x => x.SecondMove.ToNamedApiResource())
                .ToList();

            var normalUseAfter = move
                .ContestCombosSecondMove
                .Select(x => x.FirstMove.ToNamedApiResource())
                .ToList();

            var superUseBefore = move
                .SuperContestCombosFirstMove
                .Select(x => x.SecondMove.ToNamedApiResource())
                .ToList();

            var superUseAfter = move
                .SuperContestCombosSecondMove
                .Select(x => x.FirstMove.ToNamedApiResource())
                .ToList();

            var fnua = normalUseAfter.Any();
            var fnub = normalUseBefore.Any();
            var fsua = superUseAfter.Any();
            var fsub = superUseBefore.Any();

            return fnua || fnub || fsua || fsub
                ? new ContestComboSets
                {
                    Normal = new ContestComboDetail
                    {
                        UseAfter = fnua ? normalUseAfter : null,
                        UseBefore = fnub ? normalUseBefore : null
                    },
                    Super = new ContestComboDetail
                    {
                        UseAfter = fsua ? superUseAfter : null,
                        UseBefore = fsub ? superUseBefore : null
                    }
                }
                : null;
        }

        private static NamedAPIResource GetContestType(EFMoves move)
        {
            return move
                .ContestType?
                .ToNamedApiResource();
        }

        private static APIResource GetContestEffect(EFMoves move)
        {
            return move
                .ContestEffect?
                .ToApiResource();
        }

        private static NamedAPIResource GetDamageClass(EFMoves move)
        {
            return move
                .DamageClass?
                .ToNamedApiResource();
        }

        private static List<VerboseEffect> GetEffectEntries(EFMoves move)
        {
            return move
                .Effect
                .MoveEffectProse
                .Where(x => x.ShortEffect != null && x.Effect != null)
                .Select(x => new VerboseEffect(x.Effect, x.ShortEffect, x.LocalLanguage?.ToNamedApiResource()))
                .ToList();
        }

        private static List<AbilityEffectChange> GetEffectChanges(EFMoves move)
        {
            return move
                .Effect
                .MoveEffectChangelog
                .Select(x =>
                {
                    var effectEntries = x.MoveEffectChangelogProse
                        .Select(y => new Effect(y.Effect, y.LocalLanguage.ToNamedApiResource()))
                        .ToList();

                    return new AbilityEffectChange(effectEntries, x.ChangedInVersionGroup?.ToNamedApiResource());
                })
                .ToList();
        }

        private static List<MoveFlavorText> GetFlavorTextEntries(EFMoves move)
        {
            return move
                .MoveFlavorText
                .Select(x => new MoveFlavorText(x.FlavorText,
                    x.Language.ToNamedApiResource(), x.VersionGroup.ToNamedApiResource()))
                .ToList();
        }

        private static NamedAPIResource GetGeneration(EFMoves move)
        {
            return move
                .Generation?
                .ToNamedApiResource();
        }

        private static List<MachineVersionDetail> GetMachines(EFMoves move)
        {
            return move
                .Machines
                .Select(x => new MachineVersionDetail(x.ToApiResource(), x.VersionGroup?.ToNamedApiResource()))
                .ToList();
        }

        private static MoveMetaData GetMeta(EFMoves move)
        {
            var meta = move.MoveMeta;

            return new MoveMetaData
            {
                Ailment       = meta.MetaAilment?.ToNamedApiResource(),
                Category      = meta.MetaCategory?.ToNamedApiResource(),
                MinHits       = meta.MinHits,
                MaxHits       = meta.MaxHits,
                MinTurns      = meta.MinTurns,
                MaxTurns      = meta.MaxTurns,
                Drain         = meta.Drain,
                Healing       = meta.Healing,
                CritRate      = meta.CritRate,
                AilmentChance = meta.AilmentChance,
                FlinchChance  = meta.FlinchChance,
                StatChance    = meta.StatChance
            };
        }

        private static List<Name> GetNames(EFMoves move)
        {
            return move
                .MoveNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<PastMoveStatValues> GetPastValues(EFMoves move)
        {
            return move
                .MoveChangelog
                .Select(moveChangelog =>
                {
                    var effectEntries = moveChangelog
                        .Effect?
                        .MoveEffectProse?
                        .Where(m => m.ShortEffect != null && moveChangelog.Effect != null)
                        .Select(m => new VerboseEffect(m.Effect /*TODO: Parse this result*/,
                            m.ShortEffect, m.LocalLanguage.ToNamedApiResource()))
                        .ToList();

                    return new PastMoveStatValues
                    {
                        Accuracy      = moveChangelog.Accuracy,
                        EffectChance  = moveChangelog.EffectChance,
                        Power         = moveChangelog.Power,
                        Pp            = moveChangelog.Pp,
                        EffectEntries = effectEntries,
                        Type          = moveChangelog.Type?.ToNamedApiResource(),
                        VersionGroup  = moveChangelog.ChangedInVersionGroup?.ToNamedApiResource()
                    };
                })
                .ToList();
        }

        private static List<MoveStatChange> GetStatChanges(EFMoves move)
        {
            return move
                .MoveMetaStatChanges
                .Select(x => new MoveStatChange(x.Change, x.Stat.ToNamedApiResource()))
                .ToList();
        }

        private static APIResource GetSuperContestEffect(EFMoves move)
        {
            return move
                .SuperContestEffect?
                .ToApiResource();
        }

        private static NamedAPIResource GetTarget(EFMoves move)
        {
            return move
                .Target?
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetType(EFMoves move)
        {
            return move
                .Type?
                .ToNamedApiResource();
        }
    }
}