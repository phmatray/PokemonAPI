using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFCharacteristicText : IEFModel
    {
        public int CharacteristicId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Message { get; set; }

        public virtual EFCharacteristics Characteristic { get; set; }
        public virtual EFLanguages LocalLanguage { get; set; }
    }
}
