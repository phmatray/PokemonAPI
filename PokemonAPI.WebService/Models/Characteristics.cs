using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFCharacteristics : IEFId
    {
        public EFCharacteristics()
        {
            CharacteristicText = new HashSet<EFCharacteristicText>();
        }

        public int Id { get; set; }
        public int StatId { get; set; }
        public int GeneMod5 { get; set; }

        public ICollection<EFCharacteristicText> CharacteristicText { get; set; }
        public EFStats Stat { get; set; }
    }
}
