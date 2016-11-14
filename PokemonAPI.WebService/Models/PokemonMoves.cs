using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokemonMoves : IEFModel
    {
        public int PokemonId { get; set; }
        public int VersionGroupId { get; set; }
        public int MoveId { get; set; }
        public int PokemonMoveMethodId { get; set; }
        public int Level { get; set; }
        public int? Order { get; set; }

        public virtual EFMoves Move { get; set; }
        public virtual EFPokemon Pokemon { get; set; }
        public virtual EFPokemonMoveMethods PokemonMoveMethod { get; set; }
        public virtual EFVersionGroups VersionGroup { get; set; }
    }
}
