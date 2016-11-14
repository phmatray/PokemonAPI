using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFEvolutionChains : IEFId
    {
        public EFEvolutionChains()
        {
            PokemonSpecies = new HashSet<EFPokemonSpecies>();
        }

        public int Id { get; set; }
        public int? BabyTriggerItemId { get; set; }

        public ICollection<EFPokemonSpecies> PokemonSpecies { get; set; }
        public EFItems BabyTriggerItem { get; set; }
    }
}
