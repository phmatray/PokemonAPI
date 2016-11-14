using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class EncounterMethod
    {
        /// <summary>
        /// The identifier for this encounter method resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this encounter method resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A good value for sorting
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The name of this encounter method listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

    }
}