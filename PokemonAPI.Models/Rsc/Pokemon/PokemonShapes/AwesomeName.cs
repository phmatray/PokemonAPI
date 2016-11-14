namespace PokemonAPI.Models.Rsc
{
    public class AwesomeName
    {
        public AwesomeName(string awesomeNameValue, NamedAPIResource language)
        {
            AwesomeNameValue = awesomeNameValue;
            Language = language;
        }

        /// <summary>
        /// The localized "scientific" name for an API resource in a specific language
        /// </summary>
        public string AwesomeNameValue { get; set; }

        /// <summary>
        /// The language this "scientific" name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

    }
}