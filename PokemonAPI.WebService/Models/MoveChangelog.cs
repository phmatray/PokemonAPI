using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFMoveChangelog : IEFModel
    {
        public int MoveId { get; set; }
        public int ChangedInVersionGroupId { get; set; }
        public int? TypeId { get; set; }
        public short? Power { get; set; }
        public short? Pp { get; set; }
        public short? Accuracy { get; set; }
        public int? EffectId { get; set; }
        public int? EffectChance { get; set; }

        public virtual EFVersionGroups ChangedInVersionGroup { get; set; }
        public virtual EFMoveEffects Effect { get; set; }
        public virtual EFMoves Move { get; set; }
        public virtual EFTypes Type { get; set; }
    }
}
