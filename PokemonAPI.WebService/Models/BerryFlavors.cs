using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFBerryFlavors : IEFModel
    {
        public int BerryId { get; set; }
        public int ContestTypeId { get; set; }
        public int Flavor { get; set; }

        public virtual EFBerries Berry { get; set; }
        public virtual EFContestTypes ContestType { get; set; }
    }
}
