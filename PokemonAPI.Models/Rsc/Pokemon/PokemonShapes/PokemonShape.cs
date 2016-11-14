using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class PokemonShape
    {
        /// <summary>
        /// The identifier for this Pok�mon shape resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this Pok�mon shape resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The "scientific" name of this Pok�mon shape listed in different languages
        /// </summary>
        public List<AwesomeName> AwesomeNames { get; set; }

        /// <summary>
        /// The "scientific" description of this Pok�mon shape listed in different languages
        /// </summary>
        public List<Description> Descriptions { get; set; }

        /// <summary>
        /// The name of this Pok�mon shape listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of the Pok�mon species that have this shape
        /// </summary>
        public List<NamedAPIResource> PokemonSpecies { get; set; }

    }
}