namespace PokemonAPI.Models.Rsc
{
    public class Machine
    {
        /// <summary>
        /// The identifier for this machine resource
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The TM or HM item that corresponds to this machine
        /// </summary>
        public NamedAPIResource Item { get; set; }

        /// <summary>
        /// The move that is taught by this machine
        /// </summary>
        public NamedAPIResource Move { get; set; }

        /// <summary>
        /// The version group that this machine applies to
        /// </summary>
        public NamedAPIResource VersionGroup { get; set; }

    }
}