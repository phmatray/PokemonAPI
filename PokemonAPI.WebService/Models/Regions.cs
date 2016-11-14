using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFRegions : IEFIdentifier
    {
        public EFRegions()
        {
            Generations = new HashSet<EFGenerations>();
            Locations = new HashSet<EFLocations>();
            Pokedexes = new HashSet<EFPokedexes>();
            RegionNames = new HashSet<EFRegionNames>();
            VersionGroupRegions = new HashSet<EFVersionGroupRegions>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFGenerations> Generations { get; set; }
        public ICollection<EFLocations> Locations { get; set; }
        public ICollection<EFPokedexes> Pokedexes { get; set; }
        public ICollection<EFRegionNames> RegionNames { get; set; }
        public ICollection<EFVersionGroupRegions> VersionGroupRegions { get; set; }
    }
}
