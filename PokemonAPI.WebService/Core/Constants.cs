namespace PokemonAPI.WebService.Core
{
    internal static class Constants
    {
#if DEBUG
        internal const string SiteUrl = "http://localhost:50357";
#else
        internal const string SiteUrl = "http://pkmn.azurewebsites.net";
#endif
        internal const string BaseUrl = "/api/v1/";
    }
}