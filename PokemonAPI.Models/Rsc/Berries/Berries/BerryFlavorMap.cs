namespace PokemonAPI.Models.Rsc
{
    public class BerryFlavorMap
    {
        /// <summary>
        /// How powerful the referenced flavor is for this berry
        /// </summary>
        public int Potency { get; set; }

        /// <summary>
        /// The referenced berry flavor
        /// </summary>
        public NamedAPIResource Flavor { get; set; }

    }
}