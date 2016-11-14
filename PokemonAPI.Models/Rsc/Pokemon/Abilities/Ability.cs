using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Ability
    {
        /// <summary>
        /// The identifier for this ability resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this ability resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether or not this ability originated in the main series of the video games
        /// </summary>
        public bool IsMainSeries { get; set; }

        /// <summary>
        /// The generation this ability originated in
        /// </summary>
        public NamedAPIResource Generation { get; set; }

        /// <summary>
        /// The name of this ability listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// The effect of this ability listed in different languages
        /// </summary>
        public List<VerboseEffect> EffectEntries { get; set; }

        /// <summary>
        /// The list of previous effects this ability has had across version groups
        /// </summary>
        public List<AbilityEffectChange> EffectChanges { get; set; }

        /// <summary>
        /// The flavor text of this ability listed in different languages
        /// </summary>
        public List<AbilityFlavorText> FlavorTextEntries { get; set; }

        /// <summary>
        /// A list of Pokémon that could potentially have this ability
        /// </summary>
        public List<AbilityPokemon> Pokemon { get; set; }

    }
}