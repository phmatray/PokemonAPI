using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestWarriorStatNames : IEFModel
    {
        public int WarriorStatId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFConquestWarriorStats WarriorStat { get; set; }
    }
}
