using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestPokemonEvolution : IEFModel
    {
        public int EvolvedSpeciesId { get; set; }
        public int? RequiredStatId { get; set; }
        public int? MinimumStat { get; set; }
        public int? MinimumLink { get; set; }
        public int? KingdomId { get; set; }
        public int? WarriorGenderId { get; set; }
        public int? ItemId { get; set; }
        public bool RecruitingKoRequired { get; set; }

        public virtual EFPokemonSpecies EvolvedSpecies { get; set; }
        public virtual EFItems Item { get; set; }
        public virtual EFConquestKingdoms Kingdom { get; set; }
        public virtual EFConquestStats RequiredStat { get; set; }
        public virtual EFGenders WarriorGender { get; set; }
    }
}
