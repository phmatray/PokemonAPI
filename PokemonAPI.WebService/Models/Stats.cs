using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFStats : IEFIdentifier
    {
        public EFStats()
        {
            Characteristics = new HashSet<EFCharacteristics>();
            MoveMetaStatChanges = new HashSet<EFMoveMetaStatChanges>();
            NaturesDecreasedStat = new HashSet<EFNatures>();
            NaturesIncreasedStat = new HashSet<EFNatures>();
            PokemonStats = new HashSet<EFPokemonStats>();
            StatNames = new HashSet<EFStatNames>();
        }

        public int Id { get; set; }
        public int? DamageClassId { get; set; }
        public string Identifier { get; set; }
        public bool IsBattleOnly { get; set; }
        public int? GameIndex { get; set; }

        public ICollection<EFCharacteristics> Characteristics { get; set; }
        public ICollection<EFMoveMetaStatChanges> MoveMetaStatChanges { get; set; }
        public ICollection<EFNatures> NaturesDecreasedStat { get; set; }
        public ICollection<EFNatures> NaturesIncreasedStat { get; set; }
        public ICollection<EFPokemonStats> PokemonStats { get; set; }
        public ICollection<EFStatNames> StatNames { get; set; }
        public EFMoveDamageClasses DamageClass { get; set; }
    }
}
