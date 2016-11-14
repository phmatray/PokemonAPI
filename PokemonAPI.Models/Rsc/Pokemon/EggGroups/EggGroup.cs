using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class EggGroup
    {
        /// <summary>
        /// The identifier for this egg group resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this egg group resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this egg group listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of all Pokémon species that are members of this egg group
        /// </summary>
        public List<NamedAPIResource> PokemonSpecies { get; set; }

    }
}