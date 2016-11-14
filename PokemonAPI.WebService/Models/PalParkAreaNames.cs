using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPalParkAreaNames : IEFModel
    {
        public int PalParkAreaId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFPalParkAreas PalParkArea { get; set; }
    }
}
