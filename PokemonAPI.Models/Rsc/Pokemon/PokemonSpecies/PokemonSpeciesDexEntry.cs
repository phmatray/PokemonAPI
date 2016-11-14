namespace PokemonAPI.Models.Rsc
{
    public class PokemonSpeciesDexEntry
    {
        public PokemonSpeciesDexEntry(int entryNumber, NamedAPIResource pokedex)
        {
            EntryNumber = entryNumber;
            Pokedex = pokedex;
        }

        /// <summary>
        /// The index number within the Pok�dex
        /// </summary>
        public int EntryNumber { get; set; }

        /// <summary>
        /// The Pok�dex the referenced Pok�mon species can be found in
        /// </summary>
        public NamedAPIResource Pokedex { get; set; }

    }
}