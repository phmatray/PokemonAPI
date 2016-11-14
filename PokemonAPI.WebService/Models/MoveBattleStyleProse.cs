using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFMoveBattleStyleProse : IEFModel
    {
        public int MoveBattleStyleId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFMoveBattleStyles MoveBattleStyle { get; set; }
    }
}
