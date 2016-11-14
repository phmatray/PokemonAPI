namespace PokemonAPI.Models.Rsc
{
    public class ItemHolderPokemonVersionDetail
    {
        /// <summary>
        /// How often this Pokémon holds this item in this version
        /// </summary>
        public int Rarity { get; set; }

        /// <summary>
        /// The version that this item is held in by the Pokémon
        /// </summary>
        public NamedAPIResource Version { get; set; }

    }
}