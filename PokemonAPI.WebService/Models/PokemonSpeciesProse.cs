using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokemonSpeciesProse : IEFModel
    {
        public int PokemonSpeciesId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FormDescription { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFPokemonSpecies PokemonSpecies { get; set; }
    }
}
