using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFMoveBattleStyles : IEFIdentifier
    {
        public EFMoveBattleStyles()
        {
            MoveBattleStyleProse = new HashSet<EFMoveBattleStyleProse>();
            NatureBattleStylePreferences = new HashSet<EFNatureBattleStylePreferences>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFMoveBattleStyleProse> MoveBattleStyleProse { get; set; }
        public ICollection<EFNatureBattleStylePreferences> NatureBattleStylePreferences { get; set; }
    }
}
