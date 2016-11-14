using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Language
    {
        /// <summary>
        /// The identifier for this language resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this language resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether or not the games are published in this language
        /// </summary>
        public bool Official { get; set; }

        /// <summary>
        /// The two-letter code of the country where this language is spoken. Note that it is not unique.
        /// </summary>
        public string Iso639 { get; set; }

        /// <summary>
        /// The two-letter code of the language. Note that it is not unique.
        /// </summary>
        public string Iso3166 { get; set; }

        /// <summary>
        /// The name of this language listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

    }
}