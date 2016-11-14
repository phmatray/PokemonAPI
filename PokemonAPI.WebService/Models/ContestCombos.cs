using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFContestCombos : IEFModel
    {
        public int FirstMoveId { get; set; }
        public int SecondMoveId { get; set; }

        public virtual EFMoves FirstMove { get; set; }
        public virtual EFMoves SecondMove { get; set; }
    }
}
