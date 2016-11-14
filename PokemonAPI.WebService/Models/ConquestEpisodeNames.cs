using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestEpisodeNames : IEFModel
    {
        public int EpisodeId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFConquestEpisodes Episode { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
