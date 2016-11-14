namespace PokemonAPI.Models.Rsc
{
    public class MoveFlavorText
    {
        public MoveFlavorText(string flavorText, NamedAPIResource language, NamedAPIResource versionGroup)
        {
            FlavorText = flavorText;
            Language = language;
            VersionGroup = versionGroup;
        }

        /// <summary>
        /// The localized flavor text for an api resource in a specific language
        /// </summary>
        public string FlavorText { get; set; }

        /// <summary>
        /// The language this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

        /// <summary>
        /// The version group that uses this flavor text
        /// </summary>
        public NamedAPIResource VersionGroup { get; set; }

    }
}