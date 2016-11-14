using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class PastMoveStatValues
    {
        /// <summary>
        /// The percent value of how likely this move is to be successful
        /// </summary>
        public int? Accuracy { get; set; }

        /// <summary>
        /// The percent value of how likely it is this moves effect will take effect
        /// </summary>
        public int? EffectChance { get; set; }

        /// <summary>
        /// The base power of this move with a value of 0 if it does not have a base power
        /// </summary>
        public int? Power { get; set; }

        /// <summary>
        /// Power points. The number of times this move can be used
        /// </summary>
        public int? Pp { get; set; }

        /// <summary>
        /// The effect of this move listed in different languages
        /// </summary>
        public List<VerboseEffect> EffectEntries { get; set; }

        /// <summary>
        /// The elemental type of this move
        /// </summary>
        public NamedAPIResource Type { get; set; }

        /// <summary>
        /// The version group in which these move stat values were in effect
        /// </summary>
        public NamedAPIResource VersionGroup { get; set; }

    }
}