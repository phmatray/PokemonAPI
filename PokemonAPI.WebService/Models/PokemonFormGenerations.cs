using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokemonFormGenerations : IEFModel
    {
        public int PokemonFormId { get; set; }
        public int GenerationId { get; set; }
        public int GameIndex { get; set; }

        public virtual EFGenerations Generation { get; set; }
        public virtual EFPokemonForms PokemonForm { get; set; }
    }
}
