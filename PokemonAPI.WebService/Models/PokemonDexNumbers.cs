using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokemonDexNumbers : IEFModel
    {
        public int SpeciesId { get; set; }
        public int PokedexId { get; set; }
        public int PokedexNumber { get; set; }

        public virtual EFPokedexes Pokedex { get; set; }
        public virtual EFPokemonSpecies Species { get; set; }
    }
}
