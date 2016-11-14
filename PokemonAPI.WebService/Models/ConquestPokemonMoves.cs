using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestPokemonMoves : IEFModel
    {
        public int PokemonSpeciesId { get; set; }
        public int MoveId { get; set; }

        public virtual EFMoves Move { get; set; }
        public virtual EFPokemonSpecies PokemonSpecies { get; set; }
    }
}
