using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class ContestComboDetail
    {
        /// <summary>
        /// A list of moves to use before this move
        /// </summary>
        public List<NamedAPIResource> UseBefore { get; set; }

        /// <summary>
        /// A list of moves to use after this move
        /// </summary>
        public List<NamedAPIResource> UseAfter { get; set; }

    }
}