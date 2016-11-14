using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class MoveStatAffectSets
    {
        /// <summary>
        /// A list of moves and how they change the referenced stat
        /// </summary>
        public List<MoveStatAffect> Increase { get; set; }

        /// <summary>
        /// A list of moves and how they change the referenced stat
        /// </summary>
        public List<MoveStatAffect> Decrease { get; set; }

    }
}