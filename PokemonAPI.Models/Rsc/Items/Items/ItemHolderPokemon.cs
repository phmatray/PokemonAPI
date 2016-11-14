using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class ItemHolderPokemon
    {
        /// <summary>
        /// The Pok�mon that holds this item
        /// </summary>
        public NamedAPIResource Pokemon { get; set; }

        /// <summary>
        /// The details for the version that this item is held in by the Pok�mon
        /// </summary>
        public List<ItemHolderPokemonVersionDetail> VersionDetails { get; set; }

    }
}