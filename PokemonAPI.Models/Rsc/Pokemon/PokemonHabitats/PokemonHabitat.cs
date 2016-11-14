using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class PokemonHabitat
    {
        /// <summary>
        /// The identifier for this Pok�mon habitat resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this Pok�mon habitat resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this Pok�mon habitat listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of the Pok�mon species that can be found in this habitat
        /// </summary>
        public List<NamedAPIResource> PokemonSpecies { get; set; }

    }
}