using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFEncounterConditionValueMap : IEFModel
    {
        public int EncounterId { get; set; }
        public int EncounterConditionValueId { get; set; }

        public virtual EFEncounterConditionValues EncounterConditionValue { get; set; }
        public virtual EFEncounters Encounter { get; set; }
    }
}
