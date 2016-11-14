using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class EncounterCondition
    {
        /// <summary>
        /// The identifier for this encounter condition resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this encounter condition resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this encounter method listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of possible values for this encounter condition
        /// </summary>
        public List<NamedAPIResource> Values { get; set; }

    }
}