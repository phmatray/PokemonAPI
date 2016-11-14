namespace PokemonAPI.Models.Rsc
{
    public class ItemHolderPokemonVersionDetail
    {
        /// <summary>
        /// How often this Pok�mon holds this item in this version
        /// </summary>
        public int Rarity { get; set; }

        /// <summary>
        /// The version that this item is held in by the Pok�mon
        /// </summary>
        public NamedAPIResource Version { get; set; }

    }
}