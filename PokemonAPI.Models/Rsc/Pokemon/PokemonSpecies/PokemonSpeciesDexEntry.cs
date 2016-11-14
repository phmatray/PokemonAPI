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
        /// The index number within the Pokédex
        /// </summary>
        public int EntryNumber { get; set; }

        /// <summary>
        /// The Pokédex the referenced Pokémon species can be found in
        /// </summary>
        public NamedAPIResource Pokedex { get; set; }

    }
}