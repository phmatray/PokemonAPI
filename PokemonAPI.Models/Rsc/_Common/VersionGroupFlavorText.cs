namespace PokemonAPI.Models.Rsc
{
    public class VersionGroupFlavorText
    {
        public VersionGroupFlavorText(string text, NamedAPIResource language, NamedAPIResource versionGroup)
        {
            Text = text;
            Language = language;
            VersionGroup = versionGroup;
        }

        /// <summary>
        /// The localized name for an API resource in a specific language
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The language this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

        /// <summary>
        /// The version group which uses this flavor text
        /// </summary>
        public NamedAPIResource VersionGroup { get; set; }

    }
}