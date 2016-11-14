namespace PokemonAPI.Models.Rsc
{
    public class ContestName
    {
        public ContestName(string name, string color, NamedAPIResource language)
        {
            Name = name;
            Color = color;
            Language = language;
        }

        /// <summary>
        /// The name for this contest
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The color associated with this contest's name
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The language that this name is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

    }
}