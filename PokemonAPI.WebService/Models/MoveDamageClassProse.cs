using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFMoveDamageClassProse : IEFModel
    {
        public int MoveDamageClassId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFMoveDamageClasses MoveDamageClass { get; set; }
    }
}
