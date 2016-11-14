using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFMoveMetaCategoryProse : IEFModel
    {
        public int MoveMetaCategoryId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Description { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFMoveMetaCategories MoveMetaCategory { get; set; }
    }
}
