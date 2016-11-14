using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFPokedexes : IEFIdentifier
    {
        public EFPokedexes()
        {
            PokedexProse = new HashSet<EFPokedexProse>();
            PokedexVersionGroups = new HashSet<EFPokedexVersionGroups>();
            PokemonDexNumbers = new HashSet<EFPokemonDexNumbers>();
        }

        public int Id { get; set; }
        public int? RegionId { get; set; }
        public string Identifier { get; set; }
        public bool IsMainSeries { get; set; }

        public ICollection<EFPokedexProse> PokedexProse { get; set; }
        public ICollection<EFPokedexVersionGroups> PokedexVersionGroups { get; set; }
        public ICollection<EFPokemonDexNumbers> PokemonDexNumbers { get; set; }
        public EFRegions Region { get; set; }
    }
}
