using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFGenerationNames : IEFModel
    {
        public int GenerationId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFGenerations Generation { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
