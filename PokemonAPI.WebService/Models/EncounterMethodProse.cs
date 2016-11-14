using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFEncounterMethodProse : IEFModel
    {
        public int EncounterMethodId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFEncounterMethods EncounterMethod { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
