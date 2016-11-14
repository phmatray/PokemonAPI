using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFMoveMetaAilmentNames : IEFModel
    {
        public int MoveMetaAilmentId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFMoveMetaAilments MoveMetaAilment { get; set; }
    }
}
