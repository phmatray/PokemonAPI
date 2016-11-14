using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface ISuperContestEffectsService
    {
        Task<int> Count();
        Task<List<APIResource>> GetAll(int limit, int offset);
        Task<List<APIResource>> GetAll(Expression<Func<EFSuperContestEffects, bool>> predicate, int limit, int offset);
        Task<SuperContestEffect> Get(int id);
        Task<SuperContestEffect> Get(Expression<Func<EFSuperContestEffects, bool>> predicate);
    }
}