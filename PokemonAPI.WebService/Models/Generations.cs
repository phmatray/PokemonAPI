using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFGenerations : IEFIdentifier
    {
        public EFGenerations()
        {
            Abilities = new HashSet<EFAbilities>();
            GenerationNames = new HashSet<EFGenerationNames>();
            ItemGameIndices = new HashSet<EFItemGameIndices>();
            LocationGameIndices = new HashSet<EFLocationGameIndices>();
            Moves = new HashSet<EFMoves>();
            PokemonFormGenerations = new HashSet<EFPokemonFormGenerations>();
            PokemonSpecies = new HashSet<EFPokemonSpecies>();
            TypeGameIndices = new HashSet<EFTypeGameIndices>();
            Types = new HashSet<EFTypes>();
            VersionGroups = new HashSet<EFVersionGroups>();
        }

        public int Id { get; set; }
        public int MainRegionId { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFAbilities> Abilities { get; set; }
        public ICollection<EFGenerationNames> GenerationNames { get; set; }
        public ICollection<EFItemGameIndices> ItemGameIndices { get; set; }
        public ICollection<EFLocationGameIndices> LocationGameIndices { get; set; }
        public ICollection<EFMoves> Moves { get; set; }
        public ICollection<EFPokemonFormGenerations> PokemonFormGenerations { get; set; }
        public ICollection<EFPokemonSpecies> PokemonSpecies { get; set; }
        public ICollection<EFTypeGameIndices> TypeGameIndices { get; set; }
        public ICollection<EFTypes> Types { get; set; }
        public ICollection<EFVersionGroups> VersionGroups { get; set; }
        public EFRegions MainRegion { get; set; }
    }
}
