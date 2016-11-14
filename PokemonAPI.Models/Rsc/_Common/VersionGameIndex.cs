namespace PokemonAPI.Models.Rsc
{
    public class VersionGameIndex
    {
        public VersionGameIndex(int gameIndex, NamedAPIResource version)
        {
            GameIndex = gameIndex;
            Version = version;
        }

        /// <summary>
        /// The internal id of an API resource within game data
        /// </summary>
        public int GameIndex { get; set; }

        /// <summary>
        /// The version relevent to this game index
        /// </summary>
        public NamedAPIResource Version { get; set; }

    }
}