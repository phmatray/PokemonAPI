using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFMoveTargets : IEFIdentifier
    {
        public EFMoveTargets()
        {
            Moves = new HashSet<EFMoves>();
            MoveTargetProse = new HashSet<EFMoveTargetProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFMoves> Moves { get; set; }
        public ICollection<EFMoveTargetProse> MoveTargetProse { get; set; }
    }
}
