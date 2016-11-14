using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class ItemPocket
    {
        /// <summary>
        /// The identifier for this item pocket resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this item pocket resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of item categories that are relevant to this item pocket
        /// </summary>
        public List<NamedAPIResource> Categories { get; set; }

        /// <summary>
        /// The name of this item pocket listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

    }
}