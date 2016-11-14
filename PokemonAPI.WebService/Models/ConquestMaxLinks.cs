using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestMaxLinks : IEFModel
    {
        public int WarriorRankId { get; set; }
        public int PokemonSpeciesId { get; set; }
        public int MaxLink { get; set; }

        public virtual EFPokemonSpecies PokemonSpecies { get; set; }
        public virtual EFConquestWarriorRanks WarriorRank { get; set; }
    }
}
