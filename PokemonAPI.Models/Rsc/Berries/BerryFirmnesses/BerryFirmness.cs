using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class BerryFirmness
    {
        /// <summary>
        /// The identifier for this berry firmness resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this berry firmness resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of the berries with this firmness
        /// </summary>
        public List<NamedAPIResource> Berries { get; set; }

        /// <summary>
        /// The name of this berry firmness listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

    }
}