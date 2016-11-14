using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFPokeathlonStats : IEFIdentifier
    {
        public EFPokeathlonStats()
        {
            NaturePokeathlonStats = new HashSet<EFNaturePokeathlonStats>();
            PokeathlonStatNames = new HashSet<EFPokeathlonStatNames>();
            PokemonFormPokeathlonStats = new HashSet<EFPokemonFormPokeathlonStats>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFNaturePokeathlonStats> NaturePokeathlonStats { get; set; }
        public ICollection<EFPokeathlonStatNames> PokeathlonStatNames { get; set; }
        public ICollection<EFPokemonFormPokeathlonStats> PokemonFormPokeathlonStats { get; set; }
    }
}
