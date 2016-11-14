using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFContestEffects : IEFId
    {
        public EFContestEffects()
        {
            ContestEffectProse = new HashSet<EFContestEffectProse>();
            Moves = new HashSet<EFMoves>();
        }

        public int Id { get; set; }
        public short Appeal { get; set; }
        public short Jam { get; set; }

        public ICollection<EFContestEffectProse> ContestEffectProse { get; set; }
        public ICollection<EFMoves> Moves { get; set; }
    }
}
