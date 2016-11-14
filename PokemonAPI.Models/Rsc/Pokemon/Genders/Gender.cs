using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Gender
    {
        /// <summary>
        /// The identifier for this gender resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this gender resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of Pokémon species that can be this gender and how likely it is that they will be
        /// </summary>
        public List<PokemonSpeciesGender> PokemonSpeciesDetails { get; set; }

        /// <summary>
        /// A list of Pokémon species that required this gender in order for a Pokémon to evolve into them
        /// </summary>
        public List<NamedAPIResource> RequiredForEvolution { get; set; }

    }
}