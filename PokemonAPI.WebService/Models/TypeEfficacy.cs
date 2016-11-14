using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFTypeEfficacy : IEFModel
    {
        public int DamageTypeId { get; set; }
        public int TargetTypeId { get; set; }
        public int DamageFactor { get; set; }

        public virtual EFTypes DamageType { get; set; }
        public virtual EFTypes TargetType { get; set; }
    }
}
