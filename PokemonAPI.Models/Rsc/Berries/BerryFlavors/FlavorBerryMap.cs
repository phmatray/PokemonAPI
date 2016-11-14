namespace PokemonAPI.Models.Rsc
{
    public class FlavorBerryMap
    {
        /// <summary>
        /// How powerful the referenced flavor is for this berry
        /// </summary>
        public int Potency { get; set; }

        /// <summary>
        /// The berry with the referenced flavor
        /// </summary>
        public NamedAPIResource Berry { get; set; }

    }
}