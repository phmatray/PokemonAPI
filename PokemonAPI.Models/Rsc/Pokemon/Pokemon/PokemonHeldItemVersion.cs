namespace PokemonAPI.Models.Rsc
{
    public class PokemonHeldItemVersion
    {
        public PokemonHeldItemVersion(int rarity, NamedAPIResource version)
        {
            Rarity = rarity;
            Version = version;
        }

        /// <summary>
        /// The version in which the item is held
        /// </summary>
        public NamedAPIResource Version { get; set; }

        /// <summary>
        /// How often the item is held
        /// </summary>
        public int Rarity { get; set; }

    }
}