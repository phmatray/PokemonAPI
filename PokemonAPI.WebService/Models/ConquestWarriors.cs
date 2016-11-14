using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFConquestWarriors : IEFIdentifier
    {
        public EFConquestWarriors()
        {
            ConquestEpisodeWarriors = new HashSet<EFConquestEpisodeWarriors>();
            ConquestTransformationWarriors = new HashSet<EFConquestTransformationWarriors>();
            ConquestWarriorNames = new HashSet<EFConquestWarriorNames>();
            ConquestWarriorRanks = new HashSet<EFConquestWarriorRanks>();
            ConquestWarriorSpecialties = new HashSet<EFConquestWarriorSpecialties>();
            ConquestWarriorTransformation = new HashSet<EFConquestWarriorTransformation>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }
        public int GenderId { get; set; }
        public int? ArchetypeId { get; set; }

        public ICollection<EFConquestEpisodeWarriors> ConquestEpisodeWarriors { get; set; }
        public ICollection<EFConquestTransformationWarriors> ConquestTransformationWarriors { get; set; }
        public ICollection<EFConquestWarriorNames> ConquestWarriorNames { get; set; }
        public ICollection<EFConquestWarriorRanks> ConquestWarriorRanks { get; set; }
        public ICollection<EFConquestWarriorSpecialties> ConquestWarriorSpecialties { get; set; }
        public ICollection<EFConquestWarriorTransformation> ConquestWarriorTransformation { get; set; }
        public EFConquestWarriorArchetypes Archetype { get; set; }
        public EFGenders Gender { get; set; }
    }
}
