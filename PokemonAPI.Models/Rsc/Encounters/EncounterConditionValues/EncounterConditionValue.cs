using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class EncounterConditionValue
    {
        /// <summary>
        /// The identifier for this encounter condition value resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this encounter condition value resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The condition this encounter condition value pertains to
        /// </summary>
        public NamedAPIResource Condition { get; set; }

        /// <summary>
        /// The name of this encounter condition value listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

    }
}