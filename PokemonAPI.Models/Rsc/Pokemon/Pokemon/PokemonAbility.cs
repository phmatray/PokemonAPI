namespace PokemonAPI.Models.Rsc
{
    public class PokemonAbility
    {
        public PokemonAbility(bool isHidden, int slot, NamedAPIResource ability)
        {
            IsHidden = isHidden;
            Slot = slot;
            Ability = ability;
        }

        /// <summary>
        /// Whether or not this is a hidden ability
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// The slot this ability occupies in this Pokémon species
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// The ability the Pokémon may have
        /// </summary>
        public NamedAPIResource Ability { get; set; }

    }
}