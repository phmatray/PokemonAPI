namespace PokemonAPI.Models.Rsc
{
    public class NamedAPIResource : APIResource
    {
        public NamedAPIResource(string name, string url)
            : base(url)
        {
            Name = name;
        }

        /// <summary>
        /// The name of the referenced resource
        /// </summary>
        public string Name { get; set; }
    }
}