using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokemonSpeciesFlavorSummaries : IEFModel
    {
        public int PokemonSpeciesId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FlavorSummary { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFPokemonSpecies PokemonSpecies { get; set; }
    }
}
