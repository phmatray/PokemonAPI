using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class BerryFlavor
    {
        /// <summary>
        /// The identifier for this berry flavor resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this berry flavor resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of the berries with this flavor
        /// </summary>
        public List<FlavorBerryMap> Berries { get; set; }

        /// <summary>
        /// The contest type that correlates with this berry flavor
        /// </summary>
        public NamedAPIResource ContestType { get; set; }

        /// <summary>
        /// The name of this berry flavor listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

    }
}