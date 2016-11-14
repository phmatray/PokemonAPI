using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class PokemonMove
    {
        /// <summary>
        /// The move the Pok�mon can learn
        /// </summary>
        public NamedAPIResource Move { get; set; }

        /// <summary>
        /// The details of the version in which the Pok�mon can learn the move
        /// </summary>
        public List<PokemonMoveVersion> VersionGroupDetails { get; set; }

    }
}