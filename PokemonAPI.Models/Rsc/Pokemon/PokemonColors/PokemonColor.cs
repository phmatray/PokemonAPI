using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class PokemonColor
    {
        /// <summary>
        /// The identifier for this Pok�mon color resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this Pok�mon color resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this Pok�mon color listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of the Pok�mon species that have this color
        /// </summary>
        public List<NamedAPIResource> PokemonSpecies { get; set; }

    }
}