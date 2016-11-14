using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class NatureStatAffectSets
    {
        /// <summary>
        /// A list of natures and how they change the referenced stat
        /// </summary>
        public List<NamedAPIResource> Increase { get; set; }

        /// <summary>
        /// A list of nature sand how they change the referenced stat
        /// </summary>
        public List<NamedAPIResource> Decrease { get; set; }

    }
}