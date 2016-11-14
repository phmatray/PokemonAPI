using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokemonFormPokeathlonStats : IEFModel
    {
        public int PokemonFormId { get; set; }
        public int PokeathlonStatId { get; set; }
        public int MinimumStat { get; set; }
        public int BaseStat { get; set; }
        public int MaximumStat { get; set; }

        public virtual EFPokeathlonStats PokeathlonStat { get; set; }
        public virtual EFPokemonForms PokemonForm { get; set; }
    }
}
