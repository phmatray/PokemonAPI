namespace PokemonAPI.Models.Rsc
{
    public class AbilityPokemon
    {
        public AbilityPokemon(bool isHidden, int slot, NamedAPIResource pokemon)
        {
            IsHidden = isHidden;
            Slot = slot;
            Pokemon = pokemon;
        }

        /// <summary>
        /// Whether or not this a hidden ability for the referenced Pok�mon
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Pok�mon have 3 ability 'slots' which hold references to possible abilities they could have. This is the slot of this ability for the referenced pokemon.
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// The Pok�mon this ability could belong to
        /// </summary>
        public NamedAPIResource Pokemon { get; set; }

    }
}