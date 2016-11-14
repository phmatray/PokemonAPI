using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFBerries : IEFModel
    {
        public EFBerries()
        {
            BerryFlavors = new HashSet<EFBerryFlavors>();
        }

        public int Id { get; set; }
        public int ItemId { get; set; }
        public int FirmnessId { get; set; }
        public int? NaturalGiftPower { get; set; }
        public int? NaturalGiftTypeId { get; set; }
        public int Size { get; set; }
        public int MaxHarvest { get; set; }
        public int GrowthTime { get; set; }
        public int SoilDryness { get; set; }
        public int Smoothness { get; set; }

        public ICollection<EFBerryFlavors> BerryFlavors { get; set; }
        public EFBerryFirmness Firmness { get; set; }
        public EFItems Item { get; set; }
        public EFTypes NaturalGiftType { get; set; }
    }
}
