using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFConquestEpisodes : IEFIdentifier
    {
        public EFConquestEpisodes()
        {
            ConquestEpisodeNames = new HashSet<EFConquestEpisodeNames>();
            ConquestEpisodeWarriors = new HashSet<EFConquestEpisodeWarriors>();
            ConquestWarriorTransformationCompletedEpisode = new HashSet<EFConquestWarriorTransformation>();
            ConquestWarriorTransformationCurrentEpisode = new HashSet<EFConquestWarriorTransformation>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFConquestEpisodeNames> ConquestEpisodeNames { get; set; }
        public ICollection<EFConquestEpisodeWarriors> ConquestEpisodeWarriors { get; set; }
        public ICollection<EFConquestWarriorTransformation> ConquestWarriorTransformationCompletedEpisode { get; set; }
        public ICollection<EFConquestWarriorTransformation> ConquestWarriorTransformationCurrentEpisode { get; set; }
    }
}
