namespace PokemonAPI.Models.Rsc
{
    public class PokemonSpeciesGender
    {
        /// <summary>
        /// The chance of this Pokémon being female, in eighths; or -1 for genderless
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// A Pokémon species that can be the referenced gender
        /// </summary>
        public NamedAPIResource PokemonSpecies { get; set; }

    }
}