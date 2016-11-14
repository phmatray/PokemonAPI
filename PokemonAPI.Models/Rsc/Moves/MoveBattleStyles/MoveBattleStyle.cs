using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class MoveBattleStyle
    {
        /// <summary>
        /// The identifier for this move battle style resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this move battle style resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this move battle style listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

    }
}