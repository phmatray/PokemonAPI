using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class MoveLearnMethod
    {
        /// <summary>
        /// The identifier for this move learn method resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this move learn method resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of this move learn method listed in different languages
        /// </summary>
        public List<Description> Descriptions { get; set; }

        /// <summary>
        /// The name of this move learn method listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of version groups where moves can be learned through this method
        /// </summary>
        public List<NamedAPIResource> VersionGroups { get; set; }

    }
}