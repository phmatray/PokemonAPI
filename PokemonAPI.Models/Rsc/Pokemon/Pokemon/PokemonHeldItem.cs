using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class PokemonHeldItem
    {
        public PokemonHeldItem(NamedAPIResource item, List<PokemonHeldItemVersion> versionDetails)
        {
            Item = item;
            VersionDetails = versionDetails;
        }

        /// <summary>
        /// The item the referenced Pokémon holds
        /// </summary>
        public NamedAPIResource Item { get; set; }

        /// <summary>
        /// The details of the different versions in which the item is held
        /// </summary>
        public List<PokemonHeldItemVersion> VersionDetails { get; set; }

    }
}