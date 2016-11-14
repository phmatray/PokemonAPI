using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFItemFlingEffects : IEFIdentifier
    {
        public EFItemFlingEffects()
        {
            ItemFlingEffectProse = new HashSet<EFItemFlingEffectProse>();
            Items = new HashSet<EFItems>();
        }

        public int Id { get; set; }

        public string Identifier
        {
            get
            {
                string identifier = null;
                switch (Id)
                {
                    case 1: identifier = "badly-poison"; break;
                    case 2: identifier = "burn"; break;
                    case 3: identifier = "berry-effect"; break;
                    case 4: identifier = "herb-effect"; break;
                    case 5: identifier = "paralyze"; break;
                    case 6: identifier = "poison"; break;
                    case 7: identifier = "flinch"; break;
                }
                return identifier;
            }
        }

        public ICollection<EFItemFlingEffectProse> ItemFlingEffectProse { get; set; }
        public ICollection<EFItems> Items { get; set; }
    }
}
