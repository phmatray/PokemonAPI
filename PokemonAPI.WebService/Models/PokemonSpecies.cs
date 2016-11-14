using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFPokemonSpecies : IEFIdentifier
    {
        public EFPokemonSpecies()
        {
            ConquestMaxLinks = new HashSet<EFConquestMaxLinks>();
            ConquestPokemonAbilities = new HashSet<EFConquestPokemonAbilities>();
            ConquestPokemonStats = new HashSet<EFConquestPokemonStats>();
            ConquestTransformationPokemon = new HashSet<EFConquestTransformationPokemon>();
            Pokemon = new HashSet<EFPokemon>();
            PokemonDexNumbers = new HashSet<EFPokemonDexNumbers>();
            PokemonEggGroups = new HashSet<EFPokemonEggGroups>();
            PokemonEvolutionEvolvedSpecies = new HashSet<EFPokemonEvolution>();
            PokemonEvolutionPartySpecies = new HashSet<EFPokemonEvolution>();
            PokemonEvolutionTradeSpecies = new HashSet<EFPokemonEvolution>();
            PokemonSpeciesFlavorSummaries = new HashSet<EFPokemonSpeciesFlavorSummaries>();
            PokemonSpeciesFlavorText = new HashSet<EFPokemonSpeciesFlavorText>();
            PokemonSpeciesNames = new HashSet<EFPokemonSpeciesNames>();
            PokemonSpeciesProse = new HashSet<EFPokemonSpeciesProse>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int? GenerationId { get; set; }
        public int? EvolvesFromSpeciesId { get; set; }
        public int? EvolutionChainId { get; set; }
        public int ColorId { get; set; }
        public int ShapeId { get; set; }
        public int? HabitatId { get; set; }
        public int GenderRate { get; set; }
        public int CaptureRate { get; set; }
        public int BaseHappiness { get; set; }
        public bool IsBaby { get; set; }
        public int HatchCounter { get; set; }
        public bool HasGenderDifferences { get; set; }
        public int GrowthRateId { get; set; }
        public bool FormsSwitchable { get; set; }
        public int Order { get; set; }
        public int? ConquestOrder { get; set; }

        public ICollection<EFConquestMaxLinks> ConquestMaxLinks { get; set; }
        public ICollection<EFConquestPokemonAbilities> ConquestPokemonAbilities { get; set; }
        public EFConquestPokemonEvolution ConquestPokemonEvolution { get; set; }
        public EFConquestPokemonMoves ConquestPokemonMoves { get; set; }
        public ICollection<EFConquestPokemonStats> ConquestPokemonStats { get; set; }
        public ICollection<EFConquestTransformationPokemon> ConquestTransformationPokemon { get; set; }
        public EFPalPark PalPark { get; set; }
        public ICollection<EFPokemon> Pokemon { get; set; }
        public ICollection<EFPokemonDexNumbers> PokemonDexNumbers { get; set; }
        public ICollection<EFPokemonEggGroups> PokemonEggGroups { get; set; }
        public ICollection<EFPokemonEvolution> PokemonEvolutionEvolvedSpecies { get; set; }
        public ICollection<EFPokemonEvolution> PokemonEvolutionPartySpecies { get; set; }
        public ICollection<EFPokemonEvolution> PokemonEvolutionTradeSpecies { get; set; }
        public ICollection<EFPokemonSpeciesFlavorSummaries> PokemonSpeciesFlavorSummaries { get; set; }
        public ICollection<EFPokemonSpeciesFlavorText> PokemonSpeciesFlavorText { get; set; }
        public ICollection<EFPokemonSpeciesNames> PokemonSpeciesNames { get; set; }
        public ICollection<EFPokemonSpeciesProse> PokemonSpeciesProse { get; set; }
        public EFPokemonColors Color { get; set; }
        public EFEvolutionChains EvolutionChain { get; set; }
        public EFPokemonSpecies EvolvesFromSpecies { get; set; }
        public ICollection<EFPokemonSpecies> InverseEvolvesFromSpecies { get; set; }
        public EFGenerations Generation { get; set; }
        public EFGrowthRates GrowthRate { get; set; }
        public EFPokemonHabitats Habitat { get; set; }
        public EFPokemonShapes Shape { get; set; }
    }
}
