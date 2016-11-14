using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFItemFlagMap : IEFModel
    {
        public int ItemId { get; set; }
        public int ItemFlagId { get; set; }

        public virtual EFItemFlags ItemFlag { get; set; }
        public virtual EFItems Item { get; set; }
    }
}
