using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class VersionGroup
    {
        /// <summary>
        /// The identifier for this version group resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this version group resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Order for sorting. Almost by date of release, except similar versions are grouped together.
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        /// The generation this version was introduced in
        /// </summary>
        public NamedAPIResource Generation { get; set; }

        /// <summary>
        /// A list of methods in which Pokémon can learn moves in this version group
        /// </summary>
        public List<NamedAPIResource> MoveLearnMethods { get; set; }

        /// <summary>
        /// A list of Pokédexes introduces in this version group
        /// </summary>
        public List<NamedAPIResource> Pokedexes { get; set; }

        /// <summary>
        /// A list of regions that can be visited in this version group
        /// </summary>
        public List<NamedAPIResource> Regions { get; set; }

        /// <summary>
        /// The versions this version group owns
        /// </summary>
        public List<NamedAPIResource> Versions { get; set; }

    }
}