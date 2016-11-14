using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class PokemonForm
    {
        /// <summary>
        /// The identifier for this Pokémon form resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this Pokémon form resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The order in which forms should be sorted within all forms. Multiple forms may have equal order, in which case they should fall back on sorting by name.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The order in which forms should be sorted within a species' forms
        /// </summary>
        public int FormOrder { get; set; }

        /// <summary>
        /// True for exactly one form used as the default for each Pokémon
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Whether or not this form can only happen during battle
        /// </summary>
        public bool IsBattleOnly { get; set; }

        /// <summary>
        /// Whether or not this form requires mega evolution
        /// </summary>
        public bool IsMega { get; set; }

        /// <summary>
        /// The name of this form
        /// </summary>
        public string FormName { get; set; }

        /// <summary>
        /// The Pokémon that can take on this form
        /// </summary>
        public NamedAPIResource Pokemon { get; set; }

        /// <summary>
        /// A set of sprites used to depict this Pokémon form in the game
        /// </summary>
        public PokemonFormSprites Sprites { get; set; }

        /// <summary>
        /// The version group this Pokémon form was introduced in
        /// </summary>
        public NamedAPIResource VersionGroup { get; set; }

        /// <summary>
        /// The form specific full name of this Pokémon form, or empty if the form does not have a specific name
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// The form specific form name of this Pokémon form, or empty if the form does not have a specific name
        /// </summary>
        public List<Name> FormNames { get; set; }

    }
}