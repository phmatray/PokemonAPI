using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFMoveEffects : IEFModel
    {
        public EFMoveEffects()
        {
            MoveChangelog = new HashSet<EFMoveChangelog>();
            MoveEffectChangelog = new HashSet<EFMoveEffectChangelog>();
            MoveEffectProse = new HashSet<EFMoveEffectProse>();
            Moves = new HashSet<EFMoves>();
        }

        public int Id { get; set; }

        public ICollection<EFMoveChangelog> MoveChangelog { get; set; }
        public ICollection<EFMoveEffectChangelog> MoveEffectChangelog { get; set; }
        public ICollection<EFMoveEffectProse> MoveEffectProse { get; set; }
        public ICollection<EFMoves> Moves { get; set; }
    }
}
