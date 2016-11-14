using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFEncounterConditionValues : IEFIdentifier
    {
        public EFEncounterConditionValues()
        {
            EncounterConditionValueMap = new HashSet<EFEncounterConditionValueMap>();
            EncounterConditionValueProse = new HashSet<EFEncounterConditionValueProse>();
        }

        public int Id { get; set; }
        public int EncounterConditionId { get; set; }
        public string Identifier { get; set; }
        public bool IsDefault { get; set; }

        public ICollection<EFEncounterConditionValueMap> EncounterConditionValueMap { get; set; }
        public ICollection<EFEncounterConditionValueProse> EncounterConditionValueProse { get; set; }
        public EFEncounterConditions EncounterCondition { get; set; }
    }
}
