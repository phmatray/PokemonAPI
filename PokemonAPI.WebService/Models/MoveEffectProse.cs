using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFMoveEffectProse : IEFModel
    {
        public int MoveEffectId { get; set; }
        public int LocalLanguageId { get; set; }
        public string ShortEffect { get; set; }
        public string Effect { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFMoveEffects MoveEffect { get; set; }
    }
}
