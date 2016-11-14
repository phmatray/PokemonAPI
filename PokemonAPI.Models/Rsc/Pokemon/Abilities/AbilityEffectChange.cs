using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class AbilityEffectChange
    {
        public AbilityEffectChange(List<Effect> effectEntries, NamedAPIResource versionGroup)
        {
            EffectEntries = effectEntries;
            VersionGroup = versionGroup;
        }

        /// <summary>
        /// The previous effect of this ability listed in different languages
        /// </summary>
        public List<Effect> EffectEntries { get; set; }

        /// <summary>
        /// The version group in which the previous effect of this ability originated
        /// </summary>
        public NamedAPIResource VersionGroup { get; set; }

    }
}