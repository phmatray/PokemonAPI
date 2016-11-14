namespace PokemonAPI.Models.Rsc
{
    public class PokemonStat
    {
        public PokemonStat(NamedAPIResource stat, int effort, int baseStat)
        {
            Stat = stat;
            Effort = effort;
            BaseStat = baseStat;
        }

        /// <summary>
        /// The stat the Pokémon has
        /// </summary>
        public NamedAPIResource Stat { get; set; }

        /// <summary>
        /// The effort points (EV) the Pokémon has in the stat
        /// </summary>
        public int Effort { get; set; }

        /// <summary>
        /// The base value of the stst
        /// </summary>
        public int BaseStat { get; set; }

    }
}