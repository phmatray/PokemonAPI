using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFExperience : IEFModel
    {
        public int GrowthRateId { get; set; }
        public int Level { get; set; }
        public int Experience1 { get; set; }

        public virtual EFGrowthRates GrowthRate { get; set; }
    }
}
