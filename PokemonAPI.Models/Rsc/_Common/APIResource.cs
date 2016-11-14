namespace PokemonAPI.Models.Rsc
{
    public class APIResource
    {
        public APIResource(string url)
        {
            Url = url;
        }

        /// <summary>
        /// The URL of the referenced resource
        /// </summary>
        public string Url { get; set; }

    }
}