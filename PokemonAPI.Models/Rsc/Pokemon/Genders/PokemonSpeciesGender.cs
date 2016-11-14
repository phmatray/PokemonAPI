namespace PokemonAPI.Models.Rsc
{
    public class PokemonSpeciesGender
    {
        /// <summary>
        /// The chance of this Pok�mon being female, in eighths; or -1 for genderless
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// A Pok�mon species that can be the referenced gender
        /// </summary>
        public NamedAPIResource PokemonSpecies { get; set; }

    }
}