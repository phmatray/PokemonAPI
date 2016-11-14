using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFGrowthRateProse : IEFModel
    {
        public int GrowthRateId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFGrowthRates GrowthRate { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
