using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFItemNames : IEFModel
    {
        public int ItemId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFItems Item { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
