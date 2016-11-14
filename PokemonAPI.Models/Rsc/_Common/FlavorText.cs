namespace PokemonAPI.Models.Rsc
{
    public class FlavorText
    {
        public FlavorText(string flavorTextValue, NamedAPIResource language)
        {
            FlavorTextValue = flavorTextValue;
            Language = language;
        }

        /// <summary>
        /// The localized flavor text for an API resource in a specific language
        /// </summary>
        public string FlavorTextValue { get; set; }

        /// <summary>
        /// The language this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }
    }
}