namespace PokemonAPI.Models.Rsc
{
    public class PalParkEncounterArea
    {
        public PalParkEncounterArea(int baseScore, int rate, NamedAPIResource area)
        {
            BaseScore = baseScore;
            Rate = rate;
            Area = area;
        }

        /// <summary>
        /// The base score given to the player when the referenced Pokémon is caught during a pal park run
        /// </summary>
        public int BaseScore { get; set; }

        /// <summary>
        /// The base rate for encountering the referenced Pokémon in this pal park area
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// The pal park area where this encounter happens
        /// </summary>
        public NamedAPIResource Area { get; set; }

    }
}