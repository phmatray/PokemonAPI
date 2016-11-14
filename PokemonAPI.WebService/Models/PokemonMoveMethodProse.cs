using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokemonMoveMethodProse : IEFModel
    {
        public int PokemonMoveMethodId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFPokemonMoveMethods PokemonMoveMethod { get; set; }
    }
}
