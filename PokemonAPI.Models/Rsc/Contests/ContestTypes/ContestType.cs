using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class ContestType
    {
        /// <summary>
        /// The identifier for this contest type resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this contest type resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The berry flavor that correlates with this contest type
        /// </summary>
        public NamedAPIResource BerryFlavor { get; set; }

        /// <summary>
        /// The name of this contest type listed in different languages
        /// </summary>
        public List<ContestName> Names { get; set; }

    }
}