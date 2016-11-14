using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Stat
    {
        /// <summary>
        /// The identifier for this stat resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this stat resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID the games use for this stat
        /// </summary>
        public int? GameIndex { get; set; }

        /// <summary>
        /// Whether this stat only exists within a battle
        /// </summary>
        public bool IsBattleOnly { get; set; }

        /// <summary>
        /// A detail of moves which affect this stat positively or negatively
        /// </summary>
        public MoveStatAffectSets AffectingMoves { get; set; }

        /// <summary>
        /// A detail of natures which affect this stat positively or negatively
        /// </summary>
        public NatureStatAffectSets AffectingNatures { get; set; }

        /// <summary>
        /// A list of characteristics that are set on a Pokémon when its highest base stat is this stat
        /// </summary>
        public List<APIResource> Characteristics { get; set; }

        /// <summary>
        /// The class of damage this stat is directly related to
        /// </summary>
        public NamedAPIResource MoveDamageClass { get; set; }

        /// <summary>
        /// The name of this region listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

    }
}