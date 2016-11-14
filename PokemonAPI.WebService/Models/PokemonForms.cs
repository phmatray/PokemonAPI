using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFPokemonForms : IEFIdentifier
    {
        public EFPokemonForms()
        {
            PokemonFormGenerations = new HashSet<EFPokemonFormGenerations>();
            PokemonFormNames = new HashSet<EFPokemonFormNames>();
            PokemonFormPokeathlonStats = new HashSet<EFPokemonFormPokeathlonStats>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public string FormIdentifier { get; set; }
        public int PokemonId { get; set; }
        public int? IntroducedInVersionGroupId { get; set; }
        public bool IsDefault { get; set; }
        public bool IsBattleOnly { get; set; }
        public bool IsMega { get; set; }
        public int FormOrder { get; set; }
        public int Order { get; set; }

        public ICollection<EFPokemonFormGenerations> PokemonFormGenerations { get; set; }
        public ICollection<EFPokemonFormNames> PokemonFormNames { get; set; }
        public ICollection<EFPokemonFormPokeathlonStats> PokemonFormPokeathlonStats { get; set; }
        public EFVersionGroups IntroducedInVersionGroup { get; set; }
        public EFPokemon Pokemon { get; set; }
    }
}
