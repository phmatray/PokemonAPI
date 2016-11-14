using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFVersionGroups : IEFIdentifier
    {
        public EFVersionGroups()
        {
            AbilityChangelog = new HashSet<EFAbilityChangelog>();
            AbilityFlavorText = new HashSet<EFAbilityFlavorText>();
            EncounterSlots = new HashSet<EFEncounterSlots>();
            ItemFlavorText = new HashSet<EFItemFlavorText>();
            Machines = new HashSet<EFMachines>();
            MoveChangelog = new HashSet<EFMoveChangelog>();
            MoveEffectChangelog = new HashSet<EFMoveEffectChangelog>();
            MoveFlavorText = new HashSet<EFMoveFlavorText>();
            PokedexVersionGroups = new HashSet<EFPokedexVersionGroups>();
            PokemonForms = new HashSet<EFPokemonForms>();
            PokemonMoves = new HashSet<EFPokemonMoves>();
            VersionGroupPokemonMoveMethods = new HashSet<EFVersionGroupPokemonMoveMethods>();
            VersionGroupRegions = new HashSet<EFVersionGroupRegions>();
            Versions = new HashSet<EFVersions>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int GenerationId { get; set; }
        public int? Order { get; set; }

        public ICollection<EFAbilityChangelog> AbilityChangelog { get; set; }
        public ICollection<EFAbilityFlavorText> AbilityFlavorText { get; set; }
        public ICollection<EFEncounterSlots> EncounterSlots { get; set; }
        public ICollection<EFItemFlavorText> ItemFlavorText { get; set; }
        public ICollection<EFMachines> Machines { get; set; }
        public ICollection<EFMoveChangelog> MoveChangelog { get; set; }
        public ICollection<EFMoveEffectChangelog> MoveEffectChangelog { get; set; }
        public ICollection<EFMoveFlavorText> MoveFlavorText { get; set; }
        public ICollection<EFPokedexVersionGroups> PokedexVersionGroups { get; set; }
        public ICollection<EFPokemonForms> PokemonForms { get; set; }
        public ICollection<EFPokemonMoves> PokemonMoves { get; set; }
        public ICollection<EFVersionGroupPokemonMoveMethods> VersionGroupPokemonMoveMethods { get; set; }
        public ICollection<EFVersionGroupRegions> VersionGroupRegions { get; set; }
        public ICollection<EFVersions> Versions { get; set; }
        public EFGenerations Generation { get; set; }
    }
}
