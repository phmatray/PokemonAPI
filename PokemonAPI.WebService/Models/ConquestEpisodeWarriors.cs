using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestEpisodeWarriors : IEFModel
    {
        public int EpisodeId { get; set; }
        public int WarriorId { get; set; }

        public virtual EFConquestEpisodes Episode { get; set; }
        public virtual EFConquestWarriors Warrior { get; set; }
    }
}
