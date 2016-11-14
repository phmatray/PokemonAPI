using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFPokemonShapes : IEFIdentifier
    {
        public EFPokemonShapes()
        {
            PokemonShapeProse = new HashSet<EFPokemonShapeProse>();
            PokemonSpecies = new HashSet<EFPokemonSpecies>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFPokemonShapeProse> PokemonShapeProse { get; set; }
        public ICollection<EFPokemonSpecies> PokemonSpecies { get; set; }
    }
}
