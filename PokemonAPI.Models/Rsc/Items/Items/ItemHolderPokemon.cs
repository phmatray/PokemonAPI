using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class ItemHolderPokemon
    {
        /// <summary>
        /// The Pokémon that holds this item
        /// </summary>
        public NamedAPIResource Pokemon { get; set; }

        /// <summary>
        /// The details for the version that this item is held in by the Pokémon
        /// </summary>
        public List<ItemHolderPokemonVersionDetail> VersionDetails { get; set; }

    }
}