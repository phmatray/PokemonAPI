using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFNatures : IEFIdentifier
    {
        public EFNatures()
        {
            NatureBattleStylePreferences = new HashSet<EFNatureBattleStylePreferences>();
            NatureNames = new HashSet<EFNatureNames>();
            NaturePokeathlonStats = new HashSet<EFNaturePokeathlonStats>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int DecreasedStatId { get; set; }
        public int IncreasedStatId { get; set; }
        public int HatesFlavorId { get; set; }
        public int LikesFlavorId { get; set; }
        public int GameIndex { get; set; }

        public ICollection<EFNatureBattleStylePreferences> NatureBattleStylePreferences { get; set; }
        public ICollection<EFNatureNames> NatureNames { get; set; }
        public ICollection<EFNaturePokeathlonStats> NaturePokeathlonStats { get; set; }
        public EFStats DecreasedStat { get; set; }
        public EFContestTypes HatesFlavor { get; set; }
        public EFStats IncreasedStat { get; set; }
        public EFContestTypes LikesFlavor { get; set; }
    }
}
