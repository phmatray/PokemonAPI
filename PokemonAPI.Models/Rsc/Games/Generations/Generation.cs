using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Generation
    {
        /// <summary>
        /// The identifier for this generation resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this generation resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of abilities that were introduced in this generation
        /// </summary>
        public List<NamedAPIResource> Abilities { get; set; }

        /// <summary>
        /// The name of this generation listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// The main region travelled in this generation
        /// </summary>
        public NamedAPIResource MainRegion { get; set; }

        /// <summary>
        /// A list of moves that were introduced in this generation
        /// </summary>
        public List<NamedAPIResource> Moves { get; set; }

        /// <summary>
        /// A list of Pokémon species that were introduced in this generation
        /// </summary>
        public List<NamedAPIResource> PokemonSpecies { get; set; }

        /// <summary>
        /// A list of types that were introduced in this generation
        /// </summary>
        public List<NamedAPIResource> Types { get; set; }

        /// <summary>
        /// A list of version groups that were introduced in this generation
        /// </summary>
        public List<NamedAPIResource> VersionGroups { get; set; }

    }
}