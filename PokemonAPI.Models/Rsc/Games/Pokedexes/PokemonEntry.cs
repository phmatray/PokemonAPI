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
        /// The index of this Pok�mon species entry within the Pok�dex
        /// </summary>
        public int EntryNumber { get; set; }

        /// <summary>
        /// The Pok�mon species being encountered
        /// </summary>
        public NamedAPIResource PokemonSpecies { get; set; }

    }
}