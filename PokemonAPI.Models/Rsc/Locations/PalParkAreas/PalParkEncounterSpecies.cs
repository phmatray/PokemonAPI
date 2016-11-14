namespace PokemonAPI.Models.Rsc
{
    public class PalParkEncounterSpecies
    {
        public PalParkEncounterSpecies(int baseScore, int rate, NamedAPIResource pokemonSpecies)
        {
            BaseScore = baseScore;
            Rate = rate;
            PokemonSpecies = pokemonSpecies;
        }

        /// <summary>
        /// The base score given to the player when this Pok�mon is caught during a pal park run
        /// </summary>
        public int BaseScore { get; set; }

        /// <summary>
        /// The base rate for encountering this Pok�mon in this pal park area
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// The Pok�mon species being encountered
        /// </summary>
        public NamedAPIResource PokemonSpecies { get; set; }

    }
}