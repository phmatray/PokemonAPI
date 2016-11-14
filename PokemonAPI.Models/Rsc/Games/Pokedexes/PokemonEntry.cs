namespace PokemonAPI.Models.Rsc
{
    public class PokemonEntry
    {
        public PokemonEntry(int entryNumber, NamedAPIResource pokemonSpecies)
        {
            EntryNumber = entryNumber;
            PokemonSpecies = pokemonSpecies;
        }

        /// <summary>
        /// The index of this Pokémon species entry within the Pokédex
        /// </summary>
        public int EntryNumber { get; set; }

        /// <summary>
        /// The Pokémon species being encountered
        /// </summary>
        public NamedAPIResource PokemonSpecies { get; set; }

    }
}