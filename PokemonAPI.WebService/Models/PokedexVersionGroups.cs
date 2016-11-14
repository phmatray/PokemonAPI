using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokedexVersionGroups : IEFModel
    {
        public int PokedexId { get; set; }
        public int VersionGroupId { get; set; }

        public virtual EFPokedexes Pokedex { get; set; }
        public virtual EFVersionGroups VersionGroup { get; set; }
    }
}
