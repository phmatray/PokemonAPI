using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFItems : IEFIdentifier
    {
        public EFItems()
        {
            Berries = new HashSet<EFBerries>();
            ConquestPokemonEvolution = new HashSet<EFConquestPokemonEvolution>();
            EvolutionChains = new HashSet<EFEvolutionChains>();
            ItemFlagMap = new HashSet<EFItemFlagMap>();
            ItemFlavorSummaries = new HashSet<EFItemFlavorSummaries>();
            ItemFlavorText = new HashSet<EFItemFlavorText>();
            ItemGameIndices = new HashSet<EFItemGameIndices>();
            ItemNames = new HashSet<EFItemNames>();
            ItemProse = new HashSet<EFItemProse>();
            Machines = new HashSet<EFMachines>();
            PokemonEvolutionHeldItem = new HashSet<EFPokemonEvolution>();
            PokemonEvolutionTriggerItem = new HashSet<EFPokemonEvolution>();
            PokemonItems = new HashSet<EFPokemonItems>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int CategoryId { get; set; }
        public int Cost { get; set; }
        public int? FlingPower { get; set; }
        public int? FlingEffectId { get; set; }

        public ICollection<EFBerries> Berries { get; set; }
        public ICollection<EFConquestPokemonEvolution> ConquestPokemonEvolution { get; set; }
        public ICollection<EFEvolutionChains> EvolutionChains { get; set; }
        public ICollection<EFItemFlagMap> ItemFlagMap { get; set; }
        public ICollection<EFItemFlavorSummaries> ItemFlavorSummaries { get; set; }
        public ICollection<EFItemFlavorText> ItemFlavorText { get; set; }
        public ICollection<EFItemGameIndices> ItemGameIndices { get; set; }
        public ICollection<EFItemNames> ItemNames { get; set; }
        public ICollection<EFItemProse> ItemProse { get; set; }
        public ICollection<EFMachines> Machines { get; set; }
        public ICollection<EFPokemonEvolution> PokemonEvolutionHeldItem { get; set; }
        public ICollection<EFPokemonEvolution> PokemonEvolutionTriggerItem { get; set; }
        public ICollection<EFPokemonItems> PokemonItems { get; set; }
        public EFItemCategories Category { get; set; }
        public EFItemFlingEffects FlingEffect { get; set; }
    }
}
