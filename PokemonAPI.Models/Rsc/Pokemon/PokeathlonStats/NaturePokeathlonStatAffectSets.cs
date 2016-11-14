using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class NaturePokeathlonStatAffectSets
    {
        /// <summary>
        /// A list of natures and how they change the referenced Pokéathlon stat
        /// </summary>
        public List<NaturePokeathlonStatAffect> Increase { get; set; }

        /// <summary>
        /// A list of natures and how they change the referenced Pokéathlon stat
        /// </summary>
        public List<NaturePokeathlonStatAffect> Decrease { get; set; }

    }
}