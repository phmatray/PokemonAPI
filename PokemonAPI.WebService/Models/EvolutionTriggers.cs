using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFEvolutionTriggers : IEFIdentifier
    {
        public EFEvolutionTriggers()
        {
            EvolutionTriggerProse = new HashSet<EFEvolutionTriggerProse>();
            PokemonEvolution = new HashSet<EFPokemonEvolution>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFEvolutionTriggerProse> EvolutionTriggerProse { get; set; }
        public ICollection<EFPokemonEvolution> PokemonEvolution { get; set; }
    }
}
