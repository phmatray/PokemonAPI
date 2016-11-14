using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFBerryFirmness : IEFIdentifier
    {
        public EFBerryFirmness()
        {
            Berries = new HashSet<EFBerries>();
            BerryFirmnessNames = new HashSet<EFBerryFirmnessNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFBerries> Berries { get; set; }
        public ICollection<EFBerryFirmnessNames> BerryFirmnessNames { get; set; }
    }
}
