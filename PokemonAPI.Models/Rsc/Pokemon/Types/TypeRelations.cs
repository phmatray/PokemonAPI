using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class TypeRelations
    {
        /// <summary>
        /// A list of types this type has no effect on
        /// </summary>
        public List<NamedAPIResource> NoDamageTo { get; set; }

        /// <summary>
        /// A list of types this type is not very effect against
        /// </summary>
        public List<NamedAPIResource> HalfDamageTo { get; set; }

        /// <summary>
        /// A list of types this type is effective against
        /// </summary>
        public List<NamedAPIResource> NormalDamageTo { get; set; }

        /// <summary>
        /// A list of types this type is very effect against
        /// </summary>
        public List<NamedAPIResource> DoubleDamageTo { get; set; }

        /// <summary>
        /// A list of types that have no effect on this type
        /// </summary>
        public List<NamedAPIResource> NoDamageFrom { get; set; }

        /// <summary>
        /// A list of types that are not very effective against this type
        /// </summary>
        public List<NamedAPIResource> HalfDamageFrom { get; set; }

        /// <summary>
        /// A list of types thar are effective against this type
        /// </summary>
        public List<NamedAPIResource> NormalDamageFrom { get; set; }

        /// <summary>
        /// A list of types that are very effective against this type
        /// </summary>
        public List<NamedAPIResource> DoubleDamageFrom { get; set; }

    }
}