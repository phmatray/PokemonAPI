using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class ItemFlingEffect
    {
        /// <summary>
        /// The identifier for this fling effect resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this fling effect resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The result of this fling effect listed in different languages
        /// </summary>
        public List<Effect> EffectEntries { get; set; }

        /// <summary>
        /// A list of items that have this fling effect
        /// </summary>
        public List<NamedAPIResource> Items { get; set; }

    }
}