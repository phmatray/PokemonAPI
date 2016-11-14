using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Pokemon
    {
        /// <summary>
        /// The identifier for this Pok�mon resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this Pok�mon resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The base experience gained for defeating this Pok�mon
        /// </summary>
        public int BaseExperience { get; set; }

        /// <summary>
        /// The height of this Pok�mon
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Set for exactly one Pok�mon used as the default for each species
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Order for sorting. Almost national order, except families are grouped together.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The weight of this Pok�mon
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// A list of abilities this Pok�mon could potentially have
        /// </summary>
        public List<PokemonAbility> Abilities { get; set; }

        /// <summary>
        /// A list of forms this Pok�mon can take on
        /// </summary>
        public List<NamedAPIResource> Forms { get; set; }

        /// <summary>
        /// A list of game indices relevent to Pok�mon item by generation
        /// </summary>
        public List<VersionGameIndex> GameIndices { get; set; }

        /// <summary>
        /// A list of items this Pok�mon may be holding when encountered
        /// </summary>
        public List<PokemonHeldItem> HeldItems { get; set; }

        /// <summary>
        /// A link to a list of location areas as well as encounter details pertaining to specific versions
        /// </summary>
        public string LocationAreaEncounters { get; set; }

        /// <summary>
        /// A list of moves along with learn methods and level details pertaining to specific version groups
        /// </summary>
        public List<PokemonMove> Moves { get; set; }

        /// <summary>
        /// A set of sprites used to depict this Pok�mon in the game
        /// </summary>
        public PokemonSprites Sprites { get; set; }

        /// <summary>
        /// The species this Pok�mon belongs to
        /// </summary>
        public NamedAPIResource Species { get; set; }

        /// <summary>
        /// A list of base stat values for this Pok�mon
        /// </summary>
        public List<PokemonStat> Stats { get; set; }

        /// <summary>
        /// A list of details showing types this Pok�mon has
        /// </summary>
        public List<PokemonType> Types { get; set; }

    }
}