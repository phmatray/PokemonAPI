using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFMoveEffectChangelog : IEFModel
    {
        public EFMoveEffectChangelog()
        {
            MoveEffectChangelogProse = new HashSet<EFMoveEffectChangelogProse>();
        }

        public int Id { get; set; }
        public int EffectId { get; set; }
        public int ChangedInVersionGroupId { get; set; }

        public ICollection<EFMoveEffectChangelogProse> MoveEffectChangelogProse { get; set; }
        public EFVersionGroups ChangedInVersionGroup { get; set; }
        public EFMoveEffects Effect { get; set; }
    }
}
