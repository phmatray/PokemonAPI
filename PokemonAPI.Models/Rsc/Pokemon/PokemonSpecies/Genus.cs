namespace PokemonAPI.Models.Rsc
{
    public class Genus
    {
        public Genus(string genusValue, NamedAPIResource language)
        {
            GenusValue = genusValue;
            Language = language;
        }

        /// <summary>
        /// The localized genus for the referenced Pok�mon species
        /// </summary>
        public string GenusValue { get; set; }

        /// <summary>
        /// The language this genus is in
        /// </summary>
        public NamedAPIResource Language { get; set; }

    }
}