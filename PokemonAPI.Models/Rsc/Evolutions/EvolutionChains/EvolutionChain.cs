namespace PokemonAPI.Models.Rsc
{
    public class EvolutionChain
    {
        /// <summary>
        /// The identifier for this evolution chain resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The item that a Pok�mon would be holding when mating that would trigger the egg hatching a baby Pok�mon rather than a basic Pok�mon
        /// </summary>
        public NamedAPIResource BabyTriggerItem { get; set; }

        /// <summary>
        /// The base chain link object. Each link contains evolution details for a Pok�mon in the chain. Each link references the next Pok�mon in the natural evolution order.
        /// </summary>
        public ChainLink Chain { get; set; }

    }
}