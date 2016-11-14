namespace PokemonAPI.Models.Rsc
{
    public class NatureStatChange
    {
        /// <summary>
        /// The amount of change
        /// </summary>
        public int MaxChange { get; set; }

        /// <summary>
        /// The stat being affected
        /// </summary>
        public NamedAPIResource PokeathlonStat { get; set; }

    }
}