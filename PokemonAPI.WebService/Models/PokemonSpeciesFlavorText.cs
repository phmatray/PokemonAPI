using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokemonSpeciesFlavorText : IEFModel
    {
        public int SpeciesId { get; set; }
        public int VersionId { get; set; }
        public int LanguageId { get; set; }
        public string FlavorText { get; set; }

        public virtual EFLanguages Language { get; set; }
        public virtual EFPokemonSpecies Species { get; set; }
        public virtual EFVersions Version { get; set; }
    }
}
