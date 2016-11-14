using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFBerryFirmnessNames : IEFModel
    {
        public int BerryFirmnessId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFBerryFirmness BerryFirmness { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
