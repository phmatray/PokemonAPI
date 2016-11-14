using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPalPark : IEFModel
    {
        public int SpeciesId { get; set; }
        public int AreaId { get; set; }
        public int BaseScore { get; set; }
        public int Rate { get; set; }

        public virtual EFPalParkAreas Area { get; set; }
        public virtual EFPokemonSpecies Species { get; set; }
    }
}
