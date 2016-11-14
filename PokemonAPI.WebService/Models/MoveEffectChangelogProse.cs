using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFMoveEffectChangelogProse : IEFModel
    {
        public int MoveEffectChangelogId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Effect { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFMoveEffectChangelog MoveEffectChangelog { get; set; }
    }
}
