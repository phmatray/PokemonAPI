using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokemonEggGroups : IEFModel
    {
        public int SpeciesId { get; set; }
        public int EggGroupId { get; set; }

        public virtual EFEggGroups EggGroup { get; set; }
        public virtual EFPokemonSpecies Species { get; set; }
    }
}
