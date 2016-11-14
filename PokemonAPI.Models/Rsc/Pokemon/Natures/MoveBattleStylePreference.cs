namespace PokemonAPI.Models.Rsc
{
    public class MoveBattleStylePreference
    {
        /// <summary>
        /// Chance of using the move, in percent, if HP is under one half
        /// </summary>
        public int LowHpPreference { get; set; }

        /// <summary>
        /// Chance of using the move, in percent, if HP is over one half
        /// </summary>
        public int HighHpPreference { get; set; }

        /// <summary>
        /// The move battle style
        /// </summary>
        public NamedAPIResource MoveBattleStyle { get; set; }

    }
}