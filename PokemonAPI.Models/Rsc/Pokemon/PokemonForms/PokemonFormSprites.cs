namespace PokemonAPI.Models.Rsc
{
    public class PokemonFormSprites
    {
        /// <summary>
        /// The default depiction of this Pokémon form from the front in battle
        /// </summary>
        public string FrontDefault { get; set; }

        /// <summary>
        /// The shiny depiction of this Pokémon form from the front in battle
        /// </summary>
        public string FrontShiny { get; set; }

        /// <summary>
        /// The default depiction of this Pokémon form from the back in battle
        /// </summary>
        public string BackDefault { get; set; }

        /// <summary>
        /// The shiny depiction of this Pokémon form from the back in battle
        /// </summary>
        public string BackShiny { get; set; }

    }
}