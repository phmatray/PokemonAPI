using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFMoveFlavorSummaries : IEFModel
    {
        public int MoveId { get; set; }
        public int LocalLanguageId { get; set; }
        public string FlavorSummary { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFMoves Move { get; set; }
    }
}
