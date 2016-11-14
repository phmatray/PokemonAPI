using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFPokemonHabitats : IEFIdentifier
    {
        public EFPokemonHabitats()
        {
            PokemonHabitatNames = new HashSet<EFPokemonHabitatNames>();
            PokemonSpecies = new HashSet<EFPokemonSpecies>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFPokemonHabitatNames> PokemonHabitatNames { get; set; }
        public ICollection<EFPokemonSpecies> PokemonSpecies { get; set; }
    }
}
