using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class SuperContestEffect
    {
        /// <summary>
        /// The identifier for this super contest effect resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The level of appeal this super contest effect has
        /// </summary>
        public int Appeal { get; set; }

        /// <summary>
        /// The flavor text of this super contest effect listed in different languages
        /// </summary>
        public List<FlavorText> FlavorTextEntries { get; set; }

        /// <summary>
        /// A list of moves that have the effect when used in super contests
        /// </summary>
        public List<NamedAPIResource> Moves { get; set; }

    }
}