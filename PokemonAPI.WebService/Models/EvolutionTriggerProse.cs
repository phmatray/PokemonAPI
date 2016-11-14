using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFEvolutionTriggerProse : IEFModel
    {
        public int EvolutionTriggerId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFEvolutionTriggers EvolutionTrigger { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
