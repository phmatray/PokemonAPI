using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class LocationArea
    {
        /// <summary>
        /// The identifier for this location resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this location resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The internal id of an API resource within game data
        /// </summary>
        public int GameIndex { get; set; }

        /// <summary>
        /// A list of methods in which Pokémon may be encountered in this area and how likely the method will occur depending on the version of the game
        /// </summary>
        public List<EncounterMethodRate> EncounterMethodRates { get; set; }

        /// <summary>
        /// The region this location can be found in
        /// </summary>
        public NamedAPIResource Location { get; set; }

        /// <summary>
        /// The name of this location area listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of Pokémon that can be encountered in this area along with version specific details about the encounter
        /// </summary>
        public List<PokemonEncounter> PokemonEncounters { get; set; }

    }
}