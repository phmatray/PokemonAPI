using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFItemGameIndices : IEFModel
    {
        public int ItemId { get; set; }
        public int GenerationId { get; set; }
        public int GameIndex { get; set; }

        public virtual EFGenerations Generation { get; set; }
        public virtual EFItems Item { get; set; }
    }
}
