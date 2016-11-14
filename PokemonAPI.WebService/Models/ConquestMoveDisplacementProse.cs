using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestMoveDisplacementProse : IEFModel
    {
        public int MoveDisplacementId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string ShortEffect { get; set; }
        public string Effect { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFConquestMoveDisplacements MoveDisplacement { get; set; }
    }
}
