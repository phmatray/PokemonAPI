namespace PokemonAPI.Models.Rsc
{
    public class Description
    {
        public Description(string descriptionValue, NamedAPIResource language)
        {
            DescriptionValue = descriptionValue;
            Language = language;
        }

        /// <summary>
        /// The localized description for an API resource in a specific language
        /// </summary>
        public string DescriptionValue { get; set; }

        /// <summary>
        /// The language this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

    }
}