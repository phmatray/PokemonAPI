namespace PokemonAPI.Models.Rsc
{
    public class Name
    {
        public Name(string nameValue, NamedAPIResource language)
        {
            NameValue = nameValue;
            Language = language;
        }

        /// <summary>
        /// The localized name for an API resource in a specific language
        /// </summary>
        public string NameValue { get; set; }

        /// <summary>
        /// The language this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }
    }
}