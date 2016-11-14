using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class GrowthRate
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
        /// The formula used to calculate the rate at which the Pok�mon species gains level
        /// </summary>
        public string Formula { get; set; }

        /// <summary>
        /// The descriptions of this characteristic listed in different languages
        /// </summary>
        public List<Description> Descriptions { get; set; }

        /// <summary>
        /// A list of levels and the amount of experienced needed to atain them based on this growth rate
        /// </summary>
        public List<GrowthRateExperienceLevel> Levels { get; set; }

        /// <summary>
        /// A list of Pok�mon species that gain levels at this growth rate
        /// </summary>
        public List<NamedAPIResource> PokemonSpecies { get; set; }

    }
}