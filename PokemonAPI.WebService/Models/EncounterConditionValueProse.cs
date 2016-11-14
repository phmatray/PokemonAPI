using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFEncounterConditionValueProse : IEFModel
    {
        public int EncounterConditionValueId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFEncounterConditionValues EncounterConditionValue { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
