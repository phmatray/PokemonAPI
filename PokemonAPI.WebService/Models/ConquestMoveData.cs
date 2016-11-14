using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestMoveData : IEFModel
    {
        public int MoveId { get; set; }
        public int? Power { get; set; }
        public int? Accuracy { get; set; }
        public int? EffectChance { get; set; }
        public int EffectId { get; set; }
        public int RangeId { get; set; }
        public int? DisplacementId { get; set; }

        public virtual EFConquestMoveDisplacements Displacement { get; set; }
        public virtual EFConquestMoveEffects Effect { get; set; }
        public virtual EFMoves Move { get; set; }
        public virtual EFConquestMoveRanges Range { get; set; }
    }
}
