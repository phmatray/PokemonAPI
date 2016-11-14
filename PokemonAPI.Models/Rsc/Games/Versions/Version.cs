using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Version
    {
        /// <summary>
        /// The identifier for this version resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this version resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this version listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// The version group this version belongs to
        /// </summary>
        public NamedAPIResource VersionGroup { get; set; }

    }
}