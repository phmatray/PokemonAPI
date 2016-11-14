namespace PokemonAPI.Models.Rsc
{
    public class MoveStatChange
    {
        public MoveStatChange(int change, NamedAPIResource stat)
        {
            Change = change;
            Stat = stat;
        }

        /// <summary>
        /// The amount of change
        /// </summary>
        public int Change { get; set; }

        /// <summary>
        /// The stat being affected
        /// </summary>
        public NamedAPIResource Stat { get; set; }

    }
}