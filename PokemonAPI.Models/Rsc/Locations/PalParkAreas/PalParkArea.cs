using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class PalParkArea
    {
        /// <summary>
        /// The identifier for this pal park area resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this pal park area resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this pal park area listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of Pokémon encountered in thi pal park area along with details
        /// </summary>
        public List<PalParkEncounterSpecies> PokemonEncounters { get; set; }

    }
}