namespace PokemonAPI.Models.Rsc
{
    public class TypePokemon
    {
        public TypePokemon(int slot, NamedAPIResource pokemon)
        {
            Slot = slot;
            Pokemon = pokemon;
        }

        /// <summary>
        /// The order the Pok�mon's types are listed in
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// The Pok�mon that has the referenced type
        /// </summary>
        public NamedAPIResource Pokemon { get; set; }

    }
}