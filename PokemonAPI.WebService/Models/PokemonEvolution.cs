using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFPokemonEvolution : IEFModel
    {
        public int Id { get; set; }
        public int EvolvedSpeciesId { get; set; }
        public int EvolutionTriggerId { get; set; }
        public int? TriggerItemId { get; set; }
        public int? MinimumLevel { get; set; }
        public int? GenderId { get; set; }
        public int? LocationId { get; set; }
        public int? HeldItemId { get; set; }
        public string TimeOfDay { get; set; }
        public int? KnownMoveId { get; set; }
        public int? KnownMoveTypeId { get; set; }
        public int? MinimumHappiness { get; set; }
        public int? MinimumBeauty { get; set; }
        public int? MinimumAffection { get; set; }
        public int? RelativePhysicalStats { get; set; }
        public int? PartySpeciesId { get; set; }
        public int? PartyTypeId { get; set; }
        public int? TradeSpeciesId { get; set; }
        public bool NeedsOverworldRain { get; set; }
        public bool TurnUpsideDown { get; set; }

        public virtual EFEvolutionTriggers EvolutionTrigger { get; set; }
        public virtual EFPokemonSpecies EvolvedSpecies { get; set; }
        public virtual EFGenders Gender { get; set; }
        public virtual EFItems HeldItem { get; set; }
        public virtual EFMoves KnownMove { get; set; }
        public virtual EFTypes KnownMoveType { get; set; }
        public virtual EFLocations Location { get; set; }
        public virtual EFPokemonSpecies PartySpecies { get; set; }
        public virtual EFTypes PartyType { get; set; }
        public virtual EFPokemonSpecies TradeSpecies { get; set; }
        public virtual EFItems TriggerItem { get; set; }
    }
}
