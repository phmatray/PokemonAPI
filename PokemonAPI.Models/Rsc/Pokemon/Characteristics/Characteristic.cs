using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Characteristic
    {
        /// <summary>
        /// The identifier for this characteristic resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The highest stat
        /// </summary>
        public NamedAPIResource HighestStat { get; set; }

        /// <summary>
        /// The remainder of the highest stat/IV divided by 5
        /// </summary>
        public int GeneModulo { get; set; }

        /// <summary>
        /// The possible values of the highest stat that would result in a Pokémon recieving this characteristic when divided by 5
        /// </summary>
        public List<int> PossibleValues { get; set; }

        /// <summary>
        /// The descriptions of this characteristic listed in different languages
        /// </summary>
        public List<Description> Descriptions { get; set; }

    }
}