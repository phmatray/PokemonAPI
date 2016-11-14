using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFSuperContestEffectProse : IEFModel
    {
        public int SuperContestEffectId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FlavorText { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFSuperContestEffects SuperContestEffect { get; set; }
    }
}
