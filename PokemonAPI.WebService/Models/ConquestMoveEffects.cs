using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFConquestMoveEffects : IEFModel
    {
        public EFConquestMoveEffects()
        {
            ConquestMoveData = new HashSet<EFConquestMoveData>();
            ConquestMoveEffectProse = new HashSet<EFConquestMoveEffectProse>();
        }

        public int Id { get; set; }

        public ICollection<EFConquestMoveData> ConquestMoveData { get; set; }
        public ICollection<EFConquestMoveEffectProse> ConquestMoveEffectProse { get; set; }
    }
}
