using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class ItemCategory
    {
        /// <summary>
        /// The identifier for this item category resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this item category resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of items that are a part of this category
        /// </summary>
        public List<NamedAPIResource> Items { get; set; }

        /// <summary>
        /// The name of this item category listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// The pocket items in this category would be put in
        /// </summary>
        public NamedAPIResource Pocket { get; set; }

    }
}