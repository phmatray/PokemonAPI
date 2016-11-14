using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class ChainLink
    {
        /// <summary>
        /// Whether or not this link is for a baby Pok�mon. This would only ever be true on the base link.
        /// </summary>
        public bool IsBaby { get; set; }

        /// <summary>
        /// The Pok�mon species at this point in the evolution chain
        /// </summary>
        public NamedAPIResource Species { get; set; }

        /// <summary>
        /// All details regarding the specific details of the referenced Pok�mon species evolution
        /// </summary>
        public List<EvolutionDetail> EvolutionDetails { get; set; }

        /// <summary>
        /// A List of chain objects.
        /// </summary>
        public List<ChainLink> EvolvesTo { get; set; }

    }
}