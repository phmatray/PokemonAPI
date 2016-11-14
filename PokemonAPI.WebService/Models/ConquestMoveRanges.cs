using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFConquestMoveRanges : IEFIdentifier
    {
        public EFConquestMoveRanges()
        {
            ConquestMoveData = new HashSet<EFConquestMoveData>();
            ConquestMoveRangeProse = new HashSet<EFConquestMoveRangeProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int Targets { get; set; }

        public ICollection<EFConquestMoveData> ConquestMoveData { get; set; }
        public ICollection<EFConquestMoveRangeProse> ConquestMoveRangeProse { get; set; }
    }
}
