using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class MoveAilment
    {
        /// <summary>
        /// The identifier for this move ailment resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this move ailment resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of moves that cause this ailment
        /// </summary>
        public List<NamedAPIResource> Moves { get; set; }

        /// <summary>
        /// The name of this move ailment listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

    }
}