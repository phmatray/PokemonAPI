namespace PokemonAPI.Models.Rsc
{
    public class PokemonMoveVersion
    {
        public PokemonMoveVersion(NamedAPIResource moveLearnMethod, NamedAPIResource versionGroup, int levelLearnedAt)
        {
            MoveLearnMethod = moveLearnMethod;
            VersionGroup = versionGroup;
            LevelLearnedAt = levelLearnedAt;
        }

        /// <summary>
        /// The method by which the move is learned
        /// </summary>
        public NamedAPIResource MoveLearnMethod { get; set; }

        /// <summary>
        /// The version group in which the move is learned
        /// </summary>
        public NamedAPIResource VersionGroup { get; set; }

        /// <summary>
        /// The minimum level to learn the move
        /// </summary>
        public int LevelLearnedAt { get; set; }

    }
}