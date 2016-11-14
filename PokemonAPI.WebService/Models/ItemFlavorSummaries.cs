using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFItemFlavorSummaries : IEFModel
    {
        public int ItemId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FlavorSummary { get; set; }

        public virtual EFItems Item { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
