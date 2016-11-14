using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFMoves : IEFIdentifier
    {
        public EFMoves()
        {
            ConquestPokemonMoves = new HashSet<EFConquestPokemonMoves>();
            ContestCombosFirstMove = new HashSet<EFContestCombos>();
            ContestCombosSecondMove = new HashSet<EFContestCombos>();
            Machines = new HashSet<EFMachines>();
            MoveChangelog = new HashSet<EFMoveChangelog>();
            MoveFlagMap = new HashSet<EFMoveFlagMap>();
            MoveFlavorSummaries = new HashSet<EFMoveFlavorSummaries>();
            MoveFlavorText = new HashSet<EFMoveFlavorText>();
            MoveMetaStatChanges = new HashSet<EFMoveMetaStatChanges>();
            MoveNames = new HashSet<EFMoveNames>();
            PokemonEvolution = new HashSet<EFPokemonEvolution>();
            PokemonMoves = new HashSet<EFPokemonMoves>();
            SuperContestCombosFirstMove = new HashSet<EFSuperContestCombos>();
            SuperContestCombosSecondMove = new HashSet<EFSuperContestCombos>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int GenerationId { get; set; }
        public int TypeId { get; set; }
        public short? Power { get; set; }
        public short? Pp { get; set; }
        public short? Accuracy { get; set; }
        public short Priority { get; set; }
        public int TargetId { get; set; }
        public int DamageClassId { get; set; }
        public int EffectId { get; set; }
        public int? EffectChance { get; set; }
        public int? ContestTypeId { get; set; }
        public int? ContestEffectId { get; set; }
        public int? SuperContestEffectId { get; set; }

        public EFConquestMoveData ConquestMoveData { get; set; }
        public ICollection<EFConquestPokemonMoves> ConquestPokemonMoves { get; set; }
        public ICollection<EFContestCombos> ContestCombosFirstMove { get; set; }
        public ICollection<EFContestCombos> ContestCombosSecondMove { get; set; }
        public ICollection<EFMachines> Machines { get; set; }
        public ICollection<EFMoveChangelog> MoveChangelog { get; set; }
        public ICollection<EFMoveFlagMap> MoveFlagMap { get; set; }
        public ICollection<EFMoveFlavorSummaries> MoveFlavorSummaries { get; set; }
        public ICollection<EFMoveFlavorText> MoveFlavorText { get; set; }
        public EFMoveMeta MoveMeta { get; set; }
        public ICollection<EFMoveMetaStatChanges> MoveMetaStatChanges { get; set; }
        public ICollection<EFMoveNames> MoveNames { get; set; }
        public ICollection<EFPokemonEvolution> PokemonEvolution { get; set; }
        public ICollection<EFPokemonMoves> PokemonMoves { get; set; }
        public ICollection<EFSuperContestCombos> SuperContestCombosFirstMove { get; set; }
        public ICollection<EFSuperContestCombos> SuperContestCombosSecondMove { get; set; }
        public EFContestEffects ContestEffect { get; set; }
        public EFContestTypes ContestType { get; set; }
        public EFMoveDamageClasses DamageClass { get; set; }
        public EFMoveEffects Effect { get; set; }
        public EFGenerations Generation { get; set; }
        public EFSuperContestEffects SuperContestEffect { get; set; }
        public EFMoveTargets Target { get; set; }
        public EFTypes Type { get; set; }
    }
}
