using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class MoveTarget
    {
        /// <summary>
        /// The identifier for this move target resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this move target resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of this move target listed in different languages
        /// </summary>
        public List<Description> Descriptions { get; set; }

        /// <summary>
        /// A list of moves that that are directed at this target
        /// </summary>
        public List<NamedAPIResource> Moves { get; set; }

        /// <summary>
        /// The name of this move target listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

    }
}