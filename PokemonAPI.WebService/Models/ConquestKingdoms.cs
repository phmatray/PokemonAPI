using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFConquestKingdoms : IEFIdentifier
    {
        public EFConquestKingdoms()
        {
            ConquestKingdomNames = new HashSet<EFConquestKingdomNames>();
            ConquestPokemonEvolution = new HashSet<EFConquestPokemonEvolution>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int TypeId { get; set; }

        public ICollection<EFConquestKingdomNames> ConquestKingdomNames { get; set; }
        public ICollection<EFConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public EFTypes Type { get; set; }
    }
}
