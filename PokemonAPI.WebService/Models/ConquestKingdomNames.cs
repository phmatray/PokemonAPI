using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestKingdomNames : IEFModel
    {
        public int KingdomId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFConquestKingdoms Kingdom { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
