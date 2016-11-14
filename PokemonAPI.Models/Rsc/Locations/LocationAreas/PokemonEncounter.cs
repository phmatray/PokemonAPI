using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class PokemonEncounter
    {
        public PokemonEncounter(NamedAPIResource pokemon, List<VersionEncounterDetail> versionDetails)
        {
            Pokemon = pokemon;
            VersionDetails = versionDetails;
        }

        /// <summary>
        /// The Pok�mon being encountered
        /// </summary>
        public NamedAPIResource Pokemon { get; set; }

        /// <summary>
        /// A list of versions and encounters with Pok�mon that might happen in the referenced location area
        /// </summary>
        public List<VersionEncounterDetail> VersionDetails { get; set; }

    }
}