namespace PokemonAPI.Models.Rsc
{
    public class ContestComboSets
    {
        /// <summary>
        /// A detail of moves this move can be used before or after, granting additional appeal points in contests
        /// </summary>
        public ContestComboDetail Normal { get; set; }

        /// <summary>
        /// A detail of moves this move can be used before or after, granting additional appeal points in super contests
        /// </summary>
        public ContestComboDetail Super { get; set; }

    }
}