using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokemonFormNames : IEFModel
    {
        public int PokemonFormId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FormName { get; set; }
        public string PokemonName { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFPokemonForms PokemonForm { get; set; }
    }
}
