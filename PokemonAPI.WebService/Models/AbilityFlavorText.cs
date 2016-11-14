using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFAbilityFlavorText : IEFModel
    {
        public int AbilityId { get; set; }
        public int VersionGroupId { get; set; }
        public int LanguageId { get; set; }
        public string FlavorText { get; set; }

        public virtual EFAbilities Ability { get; set; }
        public virtual EFLanguages Language { get; set; }
        public virtual EFVersionGroups VersionGroup { get; set; }
    }
}
