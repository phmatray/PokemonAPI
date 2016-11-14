using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IContestEffectsService
    {
        Task<int> Count();
        Task<List<APIResource>> GetAll(int limit, int offset);
        Task<List<APIResource>> GetAll(Expression<Func<EFContestEffects, bool>> predicate, int limit, int offset);
        Task<ContestEffect> Get(int id);
        Task<ContestEffect> Get(Expression<Func<EFContestEffects, bool>> predicate);
    }
}