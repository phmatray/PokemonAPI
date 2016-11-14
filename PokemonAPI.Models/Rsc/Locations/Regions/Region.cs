using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Region
    {
        /// <summary>
        /// The identifier for this region resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this region resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of locations that can be found in this region
        /// </summary>
        public List<NamedAPIResource> Locations { get; set; }

        /// <summary>
        /// The generation this region was introduced in
        /// </summary>
        public NamedAPIResource MainGeneration { get; set; }

        /// <summary>
        /// The name of this region listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of pokédexes that catalogue Pokémon in this region
        /// </summary>
        public List<NamedAPIResource> Pokedexes { get; set; }

        /// <summary>
        /// A list of version groups where this region can be visited
        /// </summary>
        public List<NamedAPIResource> VersionGroups { get; set; }

    }
}