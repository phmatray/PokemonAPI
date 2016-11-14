using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFConquestWarriorSkills : IEFIdentifier
    {
        public EFConquestWarriorSkills()
        {
            ConquestWarriorRanks = new HashSet<EFConquestWarriorRanks>();
            ConquestWarriorSkillNames = new HashSet<EFConquestWarriorSkillNames>();
        }

        public int Id { get; set; }
        public string Identifier { get; set; }

        public ICollection<EFConquestWarriorRanks> ConquestWarriorRanks { get; set; }
        public ICollection<EFConquestWarriorSkillNames> ConquestWarriorSkillNames { get; set; }
    }
}
