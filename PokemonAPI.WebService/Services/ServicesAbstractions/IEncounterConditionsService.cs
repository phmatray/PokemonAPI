using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IEncounterConditionsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFEncounterConditions, bool>> predicate, int limit, int offset);
        Task<EncounterCondition> Get(int id);
        Task<EncounterCondition> Get(string name);
        Task<EncounterCondition> Get(Expression<Func<EFEncounterConditions, bool>> predicate);
    }
}