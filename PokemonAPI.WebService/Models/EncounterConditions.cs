using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFEncounterConditions : IEFIdentifier
    {
        public EFEncounterConditions()
        {
            EncounterConditionProse = new HashSet<EFEncounterConditionProse>();
            EncounterConditionValues = new HashSet<EFEncounterConditionValues>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFEncounterConditionProse> EncounterConditionProse { get; set; }
        public ICollection<EFEncounterConditionValues> EncounterConditionValues { get; set; }
    }
}
