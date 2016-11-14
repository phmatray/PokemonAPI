using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFVersionGroupRegions : IEFModel
    {
        public int VersionGroupId { get; set; }
        public int RegionId { get; set; }

        public virtual EFRegions Region { get; set; }
        public virtual EFVersionGroups VersionGroup { get; set; }
    }
}
