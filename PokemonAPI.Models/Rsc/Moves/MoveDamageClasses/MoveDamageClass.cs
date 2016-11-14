using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class MoveDamageClass
    {
        /// <summary>
        /// The identifier for this move damage class resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this move damage class resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of this move damage class listed in different languages
        /// </summary>
        public List<Description> Descriptions { get; set; }

        /// <summary>
        /// A list of moves that fall into this damage class
        /// </summary>
        public List<NamedAPIResource> Moves { get; set; }

        /// <summary>
        /// The name of this move damage class listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

    }
}