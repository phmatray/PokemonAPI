using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokeathlonStatNames : IEFModel
    {
        public int PokeathlonStatId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFPokeathlonStats PokeathlonStat { get; set; }
    }
}
