using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFEncounterSlots : IEFModel
    {
        public EFEncounterSlots()
        {
            Encounters = new HashSet<EFEncounters>();
        }

        public int Id { get; set; }
        public int VersionGroupId { get; set; }
        public int EncounterMethodId { get; set; }
        public int? Slot { get; set; }
        public int? Rarity { get; set; }

        public ICollection<EFEncounters> Encounters { get; set; }
        public EFEncounterMethods EncounterMethod { get; set; }
        public EFVersionGroups VersionGroup { get; set; }
    }
}
