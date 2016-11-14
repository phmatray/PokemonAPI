using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class LocationAreaEncounter
    {
        public LocationAreaEncounter(NamedAPIResource locationArea, List<VersionEncounterDetail> versionDetails)
        {
            LocationArea = locationArea;
            VersionDetails = versionDetails;
        }

        /// <summary>
        /// The location area the referenced Pok�mon can be encountered in
        /// </summary>
        public NamedAPIResource LocationArea { get; set; }

        /// <summary>
        /// A list of versions and encounters with the referenced Pok�mon that might happen
        /// </summary>
        public List<VersionEncounterDetail> VersionDetails { get; set; }

    }
}