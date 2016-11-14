using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestPokemonStats : IEFModel
    {
        public int PokemonSpeciesId { get; set; }
        public int ConquestStatId { get; set; }
        public int BaseStat { get; set; }

        public virtual EFConquestStats ConquestStat { get; set; }
        public virtual EFPokemonSpecies PokemonSpecies { get; set; }
    }
}
