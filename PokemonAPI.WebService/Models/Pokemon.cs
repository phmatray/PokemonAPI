using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFPokemon : IEFIdentifier
    {
        public EFPokemon()
        {
            Encounters = new HashSet<EFEncounters>();
            PokemonAbilities = new HashSet<EFPokemonAbilities>();
            PokemonForms = new HashSet<EFPokemonForms>();
            PokemonGameIndices = new HashSet<EFPokemonGameIndices>();
            PokemonItems = new HashSet<EFPokemonItems>();
            PokemonMoves = new HashSet<EFPokemonMoves>();
            PokemonStats = new HashSet<EFPokemonStats>();
            PokemonTypes = new HashSet<EFPokemonTypes>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int? SpeciesId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BaseExperience { get; set; }
        public int Order { get; set; }
        public bool IsDefault { get; set; }

        public ICollection<EFEncounters> Encounters { get; set; }
        public ICollection<EFPokemonAbilities> PokemonAbilities { get; set; }
        public ICollection<EFPokemonForms> PokemonForms { get; set; }
        public ICollection<EFPokemonGameIndices> PokemonGameIndices { get; set; }
        public ICollection<EFPokemonItems> PokemonItems { get; set; }
        public ICollection<EFPokemonMoves> PokemonMoves { get; set; }
        public ICollection<EFPokemonStats> PokemonStats { get; set; }
        public ICollection<EFPokemonTypes> PokemonTypes { get; set; }
        public EFPokemonSpecies Species { get; set; }
    }
}
