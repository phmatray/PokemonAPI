using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFNaturePokeathlonStats : IEFModel
    {
        public int NatureId { get; set; }
        public int PokeathlonStatId { get; set; }
        public int MaxChange { get; set; }

        public virtual EFNatures Nature { get; set; }
        public virtual EFPokeathlonStats PokeathlonStat { get; set; }
    }
}
