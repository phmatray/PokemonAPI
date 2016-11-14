namespace PokemonAPI.Models.Rsc
{
    public class Effect
    {
        public Effect(string effectValue, NamedAPIResource language)
        {
            EffectValue = effectValue;
            Language = language;
        }

        /// <summary>
        /// The localized effect text for an API resource in a specific language
        /// </summary>
        public string EffectValue { get; set; }

        /// <summary>
        /// The language this effect is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

    }
}