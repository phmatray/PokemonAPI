using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Nature
    {
        /// <summary>
        /// The identifier for this nature resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this nature resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The stat decreased by 10% in Pokémon with this nature
        /// </summary>
        public NamedAPIResource DecreasedStat { get; set; }

        /// <summary>
        /// The stat increased by 10% in Pokémon with this nature
        /// </summary>
        public NamedAPIResource IncreasedStat { get; set; }

        /// <summary>
        /// The flavor hated by Pokémon with this nature
        /// </summary>
        public NamedAPIResource HatesFlavor { get; set; }

        /// <summary>
        /// The flavor liked by Pokémon with this nature
        /// </summary>
        public NamedAPIResource LikesFlavor { get; set; }

        /// <summary>
        /// A list of Pokéathlon stats this nature effects and how much it effects them
        /// </summary>
        public List<NatureStatChange> PokeathlonStatChanges { get; set; }

        /// <summary>
        /// A list of battle styles and how likely a Pokémon with this nature is to use them in the Battle Palace or Battle Tent.
        /// </summary>
        public List<MoveBattleStylePreference> MoveBattleStylePreferences { get; set; }

        /// <summary>
        /// The name of this nature listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

    }
}