using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFVersions : IEFIdentifier
    {
        public EFVersions()
        {
            Encounters = new HashSet<EFEncounters>();
            LocationAreaEncounterRates = new HashSet<EFLocationAreaEncounterRates>();
            PokemonGameIndices = new HashSet<EFPokemonGameIndices>();
            PokemonItems = new HashSet<EFPokemonItems>();
            PokemonSpeciesFlavorText = new HashSet<EFPokemonSpeciesFlavorText>();
            VersionNames = new HashSet<EFVersionNames>();
        }

        public int Id { get; set; }
        public int VersionGroupId { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFEncounters> Encounters { get; set; }
        public ICollection<EFLocationAreaEncounterRates> LocationAreaEncounterRates { get; set; }
        public ICollection<EFPokemonGameIndices> PokemonGameIndices { get; set; }
        public ICollection<EFPokemonItems> PokemonItems { get; set; }
        public ICollection<EFPokemonSpeciesFlavorText> PokemonSpeciesFlavorText { get; set; }
        public ICollection<EFVersionNames> VersionNames { get; set; }
        public EFVersionGroups VersionGroup { get; set; }
    }
}
