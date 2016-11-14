using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokemonHabitatNames : IEFModel
    {
        public int PokemonHabitatId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFPokemonHabitats PokemonHabitat { get; set; }
    }
}
