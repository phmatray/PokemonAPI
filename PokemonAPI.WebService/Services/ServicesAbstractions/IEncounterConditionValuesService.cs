using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IEncounterConditionValuesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFEncounterConditionValues, bool>> predicate, int limit, int offset);
        Task<EncounterConditionValue> Get(int id);
        Task<EncounterConditionValue> Get(string name);
        Task<EncounterConditionValue> Get(Expression<Func<EFEncounterConditionValues, bool>> predicate);
    }
}