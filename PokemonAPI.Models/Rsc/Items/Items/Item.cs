using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Item
    {
        /// <summary>
        /// The identifier for this item resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this item resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of this item in stores
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// The power of the move Fling when used with this item.
        /// </summary>
        public int? FlingPower { get; set; }

        /// <summary>
        /// The effect of the move Fling when used with this item
        /// </summary>
        public NamedAPIResource FlingEffect { get; set; }

        /// <summary>
        /// A list of attributes this item has
        /// </summary>
        public List<NamedAPIResource> Attributes { get; set; }

        /// <summary>
        /// The category of items this item falls into
        /// </summary>
        public NamedAPIResource Category { get; set; }

        /// <summary>
        /// The effect of this ability listed in different languages
        /// </summary>
        public List<VerboseEffect> EffectEntries { get; set; }

        /// <summary>
        /// The flavor text of this ability listed in different languages
        /// </summary>
        public List<VersionGroupFlavorText> FlavorTextEntries { get; set; }

        /// <summary>
        /// A list of game indices relevent to this item by generation
        /// </summary>
        public List<GenerationGameIndex> GameIndices { get; set; }

        /// <summary>
        /// The name of this item listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A set of sprites used to depict this item in the game
        /// </summary>
        public ItemSprites Sprites { get; set; }

        /// <summary>
        /// A list of Pokémon that might be found in the wild holding this item
        /// </summary>
        public List<ItemHolderPokemon> HeldByPokemon { get; set; }

        /// <summary>
        /// An evolution chain this item requires to produce a bay during mating
        /// </summary>
        public APIResource BabyTriggerFor { get; set; }

        /// <summary>
        /// A list of the machines related to this item
        /// </summary>
        public List<MachineVersionDetail> Machines { get; set; }

    }
}