using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class EvolutionTrigger
    {
        /// <summary>
        /// The identifier for this evolution trigger resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this evolution trigger resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this evolution trigger listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of pokemon species that result from this evolution trigger
        /// </summary>
        public List<NamedAPIResource> PokemonSpecies { get; set; }

    }
}