using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class Berry
    {
        /// <summary>
        /// The identifier for this berry resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this berry resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Time it takes the tree to grow one stage, in hours. Berry trees go through four of these growth stages before they can be picked.
        /// </summary>
        public int GrowthTime { get; set; }

        /// <summary>
        /// The maximum number of these berries that can grow on one tree in Generation IV
        /// </summary>
        public int MaxHarvest { get; set; }

        /// <summary>
        /// The power of the move "Natural Gift" when used with this Berry
        /// </summary>
        public int? NaturalGiftPower { get; set; }

        /// <summary>
        /// The size of this Berry, in millimeters
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The smoothness of this Berry, used in making Pokéblocks or Poffins
        /// </summary>
        public int Smoothness { get; set; }

        /// <summary>
        /// The speed at which this Berry dries out the soil as it grows. A higher rate means the soil dries more quickly.
        /// </summary>
        public int SoilDryness { get; set; }

        /// <summary>
        /// The firmness of this berry, used in making Pokéblocks or Poffins
        /// </summary>
        public NamedAPIResource Firmness { get; set; }

        /// <summary>
        /// A list of references to each flavor a berry can have and the potency of each of those flavors in regard to this berry
        /// </summary>
        public List<BerryFlavorMap> Flavors { get; set; }

        /// <summary>
        /// Berries are actually items. This is a reference to the item specific data for this berry.
        /// </summary>
        public NamedAPIResource Item { get; set; }

        /// <summary>
        /// The Type the move "Natural Gift" has when used with this Berry
        /// </summary>
        public NamedAPIResource NaturalGiftType { get; set; }

    }
}