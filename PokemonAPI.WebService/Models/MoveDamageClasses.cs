using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFMoveDamageClasses : IEFIdentifier
    {
        public EFMoveDamageClasses()
        {
            MoveDamageClassProse = new HashSet<EFMoveDamageClassProse>();
            Moves = new HashSet<EFMoves>();
            Stats = new HashSet<EFStats>();
            Types = new HashSet<EFTypes>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFMoveDamageClassProse> MoveDamageClassProse { get; set; }
        public ICollection<EFMoves> Moves { get; set; }
        public ICollection<EFStats> Stats { get; set; }
        public ICollection<EFTypes> Types { get; set; }
    }
}
