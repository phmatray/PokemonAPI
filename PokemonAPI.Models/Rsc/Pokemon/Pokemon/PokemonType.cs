namespace PokemonAPI.Models.Rsc
{
    public class PokemonType
    {
        public PokemonType(int slot, NamedAPIResource type)
        {
            Slot = slot;
            Type = type;
        }

        /// <summary>
        /// The order the Pok�mon's types are listed in
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// The type the referenced Pok�mon has
        /// </summary>
        public NamedAPIResource Type { get; set; }

    }
}