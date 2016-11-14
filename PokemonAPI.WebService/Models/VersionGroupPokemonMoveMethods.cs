using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFVersionGroupPokemonMoveMethods : IEFModel
    {
        public int VersionGroupId { get; set; }
        public int PokemonMoveMethodId { get; set; }

        public virtual EFPokemonMoveMethods PokemonMoveMethod { get; set; }
        public virtual EFVersionGroups VersionGroup { get; set; }
    }
}
