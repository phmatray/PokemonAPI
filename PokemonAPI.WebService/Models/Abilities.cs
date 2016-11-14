using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFAbilities : IEFIdentifier
    {
        public EFAbilities()
        {
            AbilityChangelog = new HashSet<EFAbilityChangelog>();
            AbilityFlavorText = new HashSet<EFAbilityFlavorText>();
            AbilityNames = new HashSet<EFAbilityNames>();
            AbilityProse = new HashSet<EFAbilityProse>();
            ConquestPokemonAbilities = new HashSet<EFConquestPokemonAbilities>();
            PokemonAbilities = new HashSet<EFPokemonAbilities>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int GenerationId { get; set; }
        public bool IsMainSeries { get; set; }

        public ICollection<EFAbilityChangelog> AbilityChangelog { get; set; }
        public ICollection<EFAbilityFlavorText> AbilityFlavorText { get; set; }
        public ICollection<EFAbilityNames> AbilityNames { get; set; }
        public ICollection<EFAbilityProse> AbilityProse { get; set; }
        public ICollection<EFConquestPokemonAbilities> ConquestPokemonAbilities { get; set; }
        public ICollection<EFPokemonAbilities> PokemonAbilities { get; set; }
        public EFGenerations Generation { get; set; }
    }
}
