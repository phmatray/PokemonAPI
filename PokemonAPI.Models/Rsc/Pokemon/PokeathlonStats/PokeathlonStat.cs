using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class PokeathlonStat
    {
        /// <summary>
        /// The identifier for this Pok�athlon stat resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this Pok�athlon stat resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this Pok�athlon stat listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A detail of natures which affect this Pok�athlon stat positively or negatively
        /// </summary>
        public NaturePokeathlonStatAffectSets AffectingNatures { get; set; }

    }
}