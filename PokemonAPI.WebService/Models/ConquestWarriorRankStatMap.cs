using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestWarriorRankStatMap : IEFModel
    {
        public int WarriorRankId { get; set; }
        public int WarriorStatId { get; set; }
        public int BaseStat { get; set; }

        public virtual EFConquestWarriorRanks WarriorRank { get; set; }
        public virtual EFConquestWarriorStats WarriorStat { get; set; }
    }
}
