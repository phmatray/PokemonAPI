using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestMoveEffectProse : IEFModel
    {
        public int ConquestMoveEffectId { get; set; }
        public int LocalLanguageId { get; set; }
        public string ShortEffect { get; set; }
        public string Effect { get; set; }

        public virtual EFConquestMoveEffects ConquestMoveEffect { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
