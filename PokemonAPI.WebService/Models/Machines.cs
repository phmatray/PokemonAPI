using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFMachines : IEFModel
    {
        public int MachineNumber { get; set; }
        public int VersionGroupId { get; set; }
        public int ItemId { get; set; }
        public int MoveId { get; set; }

        public virtual EFItems Item { get; set; }
        public virtual EFMoves Move { get; set; }
        public virtual EFVersionGroups VersionGroup { get; set; }
    }
}
