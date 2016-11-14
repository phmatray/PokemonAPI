using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class MoveCategory
    {
        /// <summary>
        /// The identifier for this move category resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this move category resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of moves that fall into this category
        /// </summary>
        public List<NamedAPIResource> Moves { get; set; }

        /// <summary>
        /// The description of this move ailment listed in different languages
        /// </summary>
        public List<Description> Descriptions { get; set; }

    }
}