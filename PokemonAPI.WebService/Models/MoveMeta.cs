using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFMoveMeta : IEFModel
    {
        public int MoveId { get; set; }
        public int MetaCategoryId { get; set; }
        public int MetaAilmentId { get; set; }
        public int? MinHits { get; set; }
        public int? MaxHits { get; set; }
        public int? MinTurns { get; set; }
        public int? MaxTurns { get; set; }
        public int Drain { get; set; }
        public int Healing { get; set; }
        public int CritRate { get; set; }
        public int AilmentChance { get; set; }
        public int FlinchChance { get; set; }
        public int StatChance { get; set; }

        public virtual EFMoveMetaAilments MetaAilment { get; set; }
        public virtual EFMoveMetaCategories MetaCategory { get; set; }
        public virtual EFMoves Move { get; set; }
    }
}
