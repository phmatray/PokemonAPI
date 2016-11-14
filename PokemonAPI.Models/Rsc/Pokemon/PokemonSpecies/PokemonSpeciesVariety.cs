namespace PokemonAPI.Models.Rsc
{
    public class PokemonSpeciesVariety
    {
        public PokemonSpeciesVariety(bool isDefault, NamedAPIResource pokemon)
        {
            IsDefault = isDefault;
            Pokemon = pokemon;
        }

        /// <summary>
        /// Whether this variety is the default variety
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// The Pokémon variety
        /// </summary>
        public NamedAPIResource Pokemon { get; set; }

    }
}