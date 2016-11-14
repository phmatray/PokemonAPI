using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFPokemonMoveMethods : IEFIdentifier
    {
        public EFPokemonMoveMethods()
        {
            PokemonMoveMethodProse = new HashSet<EFPokemonMoveMethodProse>();
            PokemonMoves = new HashSet<EFPokemonMoves>();
            VersionGroupPokemonMoveMethods = new HashSet<EFVersionGroupPokemonMoveMethods>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFPokemonMoveMethodProse> PokemonMoveMethodProse { get; set; }
        public ICollection<EFPokemonMoves> PokemonMoves { get; set; }
        public ICollection<EFVersionGroupPokemonMoveMethods> VersionGroupPokemonMoveMethods { get; set; }
    }
}
