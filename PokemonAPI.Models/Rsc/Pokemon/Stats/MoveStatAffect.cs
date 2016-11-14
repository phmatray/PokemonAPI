namespace PokemonAPI.Models.Rsc
{
    public class MoveStatAffect
    {
        public MoveStatAffect(int change, NamedAPIResource move)
        {
            Change = change;
            Move = move;
        }

        /// <summary>
        /// The maximum amount of change to the referenced stat
        /// </summary>
        public int Change { get; set; }

        /// <summary>
        /// The move causing the change
        /// </summary>
        public NamedAPIResource Move { get; set; }

    }
}