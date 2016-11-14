using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Pokedex
    {
        /// <summary>
        /// The identifier for this Pokédex resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this Pokédex resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether or not this Pokédex originated in the main series of the video games
        /// </summary>
        public bool IsMainSeries { get; set; }

        /// <summary>
        /// The description of this Pokédex listed in different languages
        /// </summary>
        public List<Description> Descriptions { get; set; }

        /// <summary>
        /// The name of this Pokédex listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of Pokémon catalogued in this Pokédex and their indexes
        /// </summary>
        public List<PokemonEntry> PokemonEntries { get; set; }

        /// <summary>
        /// The region this Pokédex catalogues Pokémon for
        /// </summary>
        public NamedAPIResource Region { get; set; }

        /// <summary>
        /// A list of version groups this Pokédex is relevant to
        /// </summary>
        public List<NamedAPIResource> VersionGroups { get; set; }

    }
}