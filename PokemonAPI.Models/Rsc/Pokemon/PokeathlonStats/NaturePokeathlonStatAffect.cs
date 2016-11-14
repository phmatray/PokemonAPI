namespace PokemonAPI.Models.Rsc
{
    public class NaturePokeathlonStatAffect
    {
        public NaturePokeathlonStatAffect(int maxChange, NamedAPIResource nature)
        {
            MaxChange = maxChange;
            Nature = nature;
        }

        /// <summary>
        /// The maximum amount of change to the referenced Pokéathlon stat
        /// </summary>
        public int MaxChange { get; set; }

        /// <summary>
        /// The nature causing the change
        /// </summary>
        public NamedAPIResource Nature { get; set; }

    }
}