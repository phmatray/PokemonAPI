using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFConquestWarriorTransformation : IEFModel
    {
        public EFConquestWarriorTransformation()
        {
            ConquestTransformationPokemon = new HashSet<EFConquestTransformationPokemon>();
            ConquestTransformationWarriors = new HashSet<EFConquestTransformationWarriors>();
        }

        public int TransformedWarriorRankId { get; set; }
        public bool IsAutomatic { get; set; }
        public int? RequiredLink { get; set; }
        public int? CompletedEpisodeId { get; set; }
        public int? CurrentEpisodeId { get; set; }
        public int? DistantWarriorId { get; set; }
        public int? FemaleWarlordCount { get; set; }
        public int? PokemonCount { get; set; }
        public int? CollectionTypeId { get; set; }
        public int? WarriorCount { get; set; }

        public ICollection<EFConquestTransformationPokemon> ConquestTransformationPokemon { get; set; }
        public ICollection<EFConquestTransformationWarriors> ConquestTransformationWarriors { get; set; }
        public EFTypes CollectionType { get; set; }
        public EFConquestEpisodes CompletedEpisode { get; set; }
        public EFConquestEpisodes CurrentEpisode { get; set; }
        public EFConquestWarriors DistantWarrior { get; set; }
        public EFConquestWarriorRanks TransformedWarriorRank { get; set; }
    }
}
