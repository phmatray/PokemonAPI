using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFTypeGameIndices : IEFModel
    {
        public int TypeId { get; set; }
        public int GenerationId { get; set; }
        public int GameIndex { get; set; }

        public virtual EFGenerations Generation { get; set; }
        public virtual EFTypes Type { get; set; }
    }
}
