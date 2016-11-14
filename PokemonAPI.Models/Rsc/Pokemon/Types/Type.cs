using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Type
    {
        /// <summary>
        /// The identifier for this type resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this type resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A detail of how effective this type is toward others and vice versa
        /// </summary>
        public TypeRelations DamageRelations { get; set; }

        /// <summary>
        /// A list of game indices relevent to this item by generation
        /// </summary>
        public List<GenerationGameIndex> GameIndices { get; set; }

        /// <summary>
        /// The generation this type was introduced in
        /// </summary>
        public NamedAPIResource Generation { get; set; }

        /// <summary>
        /// The class of damage inflicted by this type
        /// </summary>
        public NamedAPIResource MoveDamageClass { get; set; }

        /// <summary>
        /// The name of this type listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// A list of details of Pokémon that have this type
        /// </summary>
        public List<TypePokemon> Pokemon { get; set; }

        /// <summary>
        /// A list of moves that have this type
        /// </summary>
        public List<NamedAPIResource> Moves { get; set; }

    }
}