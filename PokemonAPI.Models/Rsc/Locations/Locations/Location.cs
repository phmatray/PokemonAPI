using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Location
    {
        /// <summary>
        /// The identifier for this location resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this location resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The region this location can be found in
        /// </summary>
        public NamedAPIResource Region { get; set; }

        /// <summary>
        /// The name of this language listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of game indices relevent to this location by generation
        /// </summary>
        public List<GenerationGameIndex> GameIndices { get; set; }

        /// <summary>
        /// Areas that can be found within this location
        /// </summary>
        public List<NamedAPIResource> Areas { get; set; }

    }
}