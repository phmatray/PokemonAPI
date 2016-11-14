using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Pokedex
    {
        /// <summary>
        /// The identifier for this Pok�dex resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this Pok�dex resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether or not this Pok�dex originated in the main series of the video games
        /// </summary>
        public bool IsMainSeries { get; set; }

        /// <summary>
        /// The description of this Pok�dex listed in different languages
        /// </summary>
        public List<Description> Descriptions { get; set; }

        /// <summary>
        /// The name of this Pok�dex listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of Pok�mon catalogued in this Pok�dex and their indexes
        /// </summary>
        public List<PokemonEntry> PokemonEntries { get; set; }

        /// <summary>
        /// The region this Pok�dex catalogues Pok�mon for
        /// </summary>
        public NamedAPIResource Region { get; set; }

        /// <summary>
        /// A list of version groups this Pok�dex is relevant to
        /// </summary>
        public List<NamedAPIResource> VersionGroups { get; set; }

    }
}