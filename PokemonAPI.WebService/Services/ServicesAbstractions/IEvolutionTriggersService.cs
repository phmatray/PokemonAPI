using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IEvolutionTriggersService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFEvolutionTriggers, bool>> predicate, int limit, int offset);
        Task<EvolutionTrigger> Get(int id);
        Task<EvolutionTrigger> Get(string name);
        Task<EvolutionTrigger> Get(Expression<Func<EFEvolutionTriggers, bool>> predicate);
    }
}