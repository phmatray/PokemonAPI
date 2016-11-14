using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFLocations : IEFIdentifier
    {
        public EFLocations()
        {
            LocationAreas = new HashSet<EFLocationAreas>();
            LocationGameIndices = new HashSet<EFLocationGameIndices>();
            LocationNames = new HashSet<EFLocationNames>();
            PokemonEvolution = new HashSet<EFPokemonEvolution>();
        }

        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFLocationAreas> LocationAreas { get; set; }
        public ICollection<EFLocationGameIndices> LocationGameIndices { get; set; }
        public ICollection<EFLocationNames> LocationNames { get; set; }
        public ICollection<EFPokemonEvolution> PokemonEvolution { get; set; }
        public EFRegions Region { get; set; }
    }
}
