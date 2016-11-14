using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFItemFlingEffectProse : IEFModel
    {
        public int ItemFlingEffectId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Effect { get; set; }

        public virtual EFItemFlingEffects ItemFlingEffect { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
