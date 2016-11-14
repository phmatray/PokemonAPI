using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFContestTypes : IEFIdentifier
    {
        public EFContestTypes()
        {
            BerryFlavors = new HashSet<EFBerryFlavors>();
            ContestTypeNames = new HashSet<EFContestTypeNames>();
            Moves = new HashSet<EFMoves>();
            NaturesHatesFlavor = new HashSet<EFNatures>();
            NaturesLikesFlavor = new HashSet<EFNatures>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFBerryFlavors> BerryFlavors { get; set; }
        public ICollection<EFContestTypeNames> ContestTypeNames { get; set; }
        public ICollection<EFMoves> Moves { get; set; }
        public ICollection<EFNatures> NaturesHatesFlavor { get; set; }
        public ICollection<EFNatures> NaturesLikesFlavor { get; set; }
    }
}
