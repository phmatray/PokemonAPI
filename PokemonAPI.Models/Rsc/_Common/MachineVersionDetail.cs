namespace PokemonAPI.Models.Rsc
{
    public class MachineVersionDetail
    {
        public MachineVersionDetail(APIResource machine, NamedAPIResource versionGroup)
        {
            Machine = machine;
            VersionGroup = versionGroup;
        }

        /// <summary>
        /// The machine that teaches a move from an item
        /// </summary>
        public APIResource Machine { get; set; }

        /// <summary>
        /// The version group of this specific machine
        /// </summary>
        public NamedAPIResource VersionGroup { get; set; }

    }
}