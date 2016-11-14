using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFPokemonColors : IEFIdentifier
    {
        public EFPokemonColors()
        {
            PokemonColorNames = new HashSet<EFPokemonColorNames>();
            PokemonSpecies = new HashSet<EFPokemonSpecies>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFPokemonColorNames> PokemonColorNames { get; set; }
        public ICollection<EFPokemonSpecies> PokemonSpecies { get; set; }
    }
}
