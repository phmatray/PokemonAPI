namespace PokemonAPI.Models.Rsc
{
    public class GrowthRateExperienceLevel
    {
        public GrowthRateExperienceLevel(int level, int experience)
        {
            Level = level;
            Experience = experience;
        }

        /// <summary>
        /// The level gained
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The amount of experience required to reach the referenced level
        /// </summary>
        public int Experience { get; set; }

    }
}