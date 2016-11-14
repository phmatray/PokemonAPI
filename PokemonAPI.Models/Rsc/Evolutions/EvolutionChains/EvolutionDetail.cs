namespace PokemonAPI.Models.Rsc
{
    public class EvolutionDetail
    {
        /// <summary>
        /// The item required to cause evolution this into Pokémon species
        /// </summary>
        public NamedAPIResource Item { get; set; }

        /// <summary>
        /// The type of event that triggers evolution into this Pokémon species
        /// </summary>
        public NamedAPIResource Trigger { get; set; }

        /// <summary>
        /// The id of the gender of the evolving Pokémon species must be in order to evolve into this Pokémon species
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// The item the evolving Pokémon species must be holding during the evolution trigger event to evolve into this Pokémon species
        /// </summary>
        public NamedAPIResource HeldItem { get; set; }

        /// <summary>
        /// The move that must be known by the evolving Pokémon species during the evolution trigger event in order to evolve into this Pokémon species
        /// </summary>
        public NamedAPIResource KnownMove { get; set; }

        /// <summary>
        /// The evolving Pokémon species must know a move with this type during the evolution trigger event in order to evolve into this Pokémon species
        /// </summary>
        public NamedAPIResource KnownMoveType { get; set; }

        /// <summary>
        /// The location the evolution must be triggered at.
        /// </summary>
        public NamedAPIResource Location { get; set; }

        /// <summary>
        /// The minimum required level of the evolving Pokémon species to evolve into this Pokémon species
        /// </summary>
        public int? MinLevel { get; set; }

        /// <summary>
        /// The minimum required level of happiness the evolving Pokémon species to evolve into this Pokémon species
        /// </summary>
        public int? MinHappiness { get; set; }

        /// <summary>
        /// The minimum required level of beauty the evolving Pokémon species to evolve into this Pokémon species
        /// </summary>
        public int? MinBeauty { get; set; }

        /// <summary>
        /// The minimum required level of affection the evolving Pokémon species to evolve into this Pokémon species
        /// </summary>
        public int? MinAffection { get; set; }

        /// <summary>
        /// Whether or not it must be raining in the overworld to cause evolution this Pokémon species
        /// </summary>
        public bool NeedsOverworldRain { get; set; }

        /// <summary>
        /// The Pokémon species that must be in the players party in order for the evolving Pokémon species to evolve into this Pokémon species
        /// </summary>
        public NamedAPIResource PartySpecies { get; set; }

        /// <summary>
        /// The player must have a Pokémon of this type in their party during the evolution trigger event in order for the evolving Pokémon species to evolve into this Pokémon species
        /// </summary>
        public NamedAPIResource PartyType { get; set; }

        /// <summary>
        /// The required relation between the Pokémon's Attack and Defense stats. 1 means Attack greater than Defense. 0 means Attack = Defense. -1 means Attack lower than Defense.
        /// </summary>
        public int? RelativePhysicalStats { get; set; }

        /// <summary>
        /// The required time of day. Day or night.
        /// </summary>
        public string TimeOfDay { get; set; }

        /// <summary>
        /// Pokémon species for which this one must be traded.
        /// </summary>
        public NamedAPIResource TradeSpecies { get; set; }

        /// <summary>
        /// Whether or not the 3DS needs to be turned upside-down as this Pokémon levels up.
        /// </summary>
        public bool TurnUpsideDown { get; set; }

    }
}