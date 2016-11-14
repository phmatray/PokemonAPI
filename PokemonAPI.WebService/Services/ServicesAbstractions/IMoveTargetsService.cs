using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IMoveTargetsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveTargets, bool>> predicate, int limit, int offset);
        Task<MoveTarget> Get(int id);
        Task<MoveTarget> Get(string name);
        Task<MoveTarget> Get(Expression<Func<EFMoveTargets, bool>> predicate);
    }
}