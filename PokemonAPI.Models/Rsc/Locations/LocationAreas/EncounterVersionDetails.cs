namespace PokemonAPI.Models.Rsc
{
    public class EncounterVersionDetails
    {
        public EncounterVersionDetails(int? rate, NamedAPIResource version)
        {
            Rate = rate;
            Version = version;
        }

        /// <summary>
        /// The chance of an encounter to occur.
        /// </summary>
        public int? Rate { get; set; }

        /// <summary>
        /// The version of the game in which the encounter can occur with the given chance.
        /// </summary>
        public NamedAPIResource Version { get; set; }

    }
}