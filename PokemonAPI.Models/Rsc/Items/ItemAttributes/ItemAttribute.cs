using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class ItemAttribute
    {
        /// <summary>
        /// The identifier for this item attribute resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this item attribute resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of items that have this attribute
        /// </summary>
        public List<NamedAPIResource> Items { get; set; }

        /// <summary>
        /// The name of this item attribute listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// The description of this item attribute listed in different languages
        /// </summary>
        public List<Description> Descriptions { get; set; }

    }
}