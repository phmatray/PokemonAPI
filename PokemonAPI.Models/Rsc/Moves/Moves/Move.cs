using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Move
    {
        /// <summary>
        /// The identifier for this move resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this move resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The percent value of how likely this move is to be successful
        /// </summary>
        public int? Accuracy { get; set; }

        /// <summary>
        /// The percent value of how likely it is this moves effect will happen
        /// </summary>
        public int? EffectChance { get; set; }

        /// <summary>
        /// Power points. The number of times this move can be used
        /// </summary>
        public int? Pp { get; set; }

        /// <summary>
        /// A value between -8 and 8. Sets the order in which moves are executed during battle. See Bulbapedia for greater detail.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// The base power of this move with a value of 0 if it does not have a base power
        /// </summary>
        public int? Power { get; set; }

        /// <summary>
        /// A detail of normal and super contest combos that require this move
        /// </summary>
        public ContestComboSets ContestCombos { get; set; }

        /// <summary>
        /// The type of appeal this move gives a Pokémon when used in a contest
        /// </summary>
        public NamedAPIResource ContestType { get; set; }

        /// <summary>
        /// The effect the move has when used in a contest
        /// </summary>
        public APIResource ContestEffect { get; set; }

        /// <summary>
        /// The type of damage the move inflicts on the target, e.g. physical
        /// </summary>
        public NamedAPIResource DamageClass { get; set; }

        /// <summary>
        /// The effect of this move listed in different languages
        /// </summary>
        public List<VerboseEffect> EffectEntries { get; set; }

        /// <summary>
        /// The list of previous effects this move has had across version groups of the games
        /// </summary>
        public List<AbilityEffectChange> EffectChanges { get; set; }

        /// <summary>
        /// The flavor text of this move listed in different languages
        /// </summary>
        public List<MoveFlavorText> FlavorTextEntries { get; set; }

        /// <summary>
        /// The generation in which this move was introduced
        /// </summary>
        public NamedAPIResource Generation { get; set; }

        /// <summary>
        /// A list of the machines that teach this move
        /// </summary>
        public List<MachineVersionDetail> Machines { get; set; }

        /// <summary>
        /// Metadata about this move
        /// </summary>
        public MoveMetaData Meta { get; set; }

        /// <summary>
        /// The name of this move listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of move resource value changes across version groups of the game
        /// </summary>
        public List<PastMoveStatValues> PastValues { get; set; }

        /// <summary>
        /// A list of stats this moves effects and how much it effects them
        /// </summary>
        public List<MoveStatChange> StatChanges { get; set; }

        /// <summary>
        /// The effect the move has when used in a super contest
        /// </summary>
        public APIResource SuperContestEffect { get; set; }

        /// <summary>
        /// The type of target that will receive the effects of the attack
        /// </summary>
        public NamedAPIResource Target { get; set; }

        /// <summary>
        /// The elemental type of this move
        /// </summary>
        public NamedAPIResource Type { get; set; }

    }
}