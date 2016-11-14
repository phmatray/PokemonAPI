using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class ContestEffect
    {
        /// <summary>
        /// The identifier for this contest type resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The base number of hearts the user of this move gets
        /// </summary>
        public int Appeal { get; set; }

        /// <summary>
        /// The base number of hearts the user's opponent loses
        /// </summary>
        public int Jam { get; set; }

        /// <summary>
        /// The result of this contest effect listed in different languages
        /// </summary>
        public List<Effect> EffectEntries { get; set; }

        /// <summary>
        /// The flavor text of this contest effect listed in different languages
        /// </summary>
        public List<FlavorText> FlavorTextEntries { get; set; }

    }
}