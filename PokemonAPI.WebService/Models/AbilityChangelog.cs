using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFAbilityChangelog : IEFModel
    {
        public EFAbilityChangelog()
        {
            AbilityChangelogProse = new HashSet<EFAbilityChangelogProse>();
        }

        public int Id { get; set; }
        public int AbilityId { get; set; }
        public int ChangedInVersionGroupId { get; set; }

        public ICollection<EFAbilityChangelogProse> AbilityChangelogProse { get; set; }
        public EFAbilities Ability { get; set; }
        public EFVersionGroups ChangedInVersionGroup { get; set; }
    }
}
