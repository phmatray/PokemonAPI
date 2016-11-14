namespace PokemonAPI.Models.Rsc
{
    public class GenerationGameIndex
    {
        public GenerationGameIndex(int gameIndex, NamedAPIResource generation)
        {
            GameIndex = gameIndex;
            Generation = generation;
        }

        /// <summary>
        /// The internal id of an API resource within game data
        /// </summary>
        public int GameIndex { get; set; }

        /// <summary>
        /// The generation relevent to this game index
        /// </summary>
        public NamedAPIResource Generation { get; set; }

    }
}