using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFAbilityNames : IEFModel
    {
        public int AbilityId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFAbilities Ability { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
