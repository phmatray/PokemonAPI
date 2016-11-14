using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IMoveLearnMethodsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonMoveMethods, bool>> predicate, int limit, int offset);
        Task<MoveLearnMethod> Get(int id);
        Task<MoveLearnMethod> Get(string name);
        Task<MoveLearnMethod> Get(Expression<Func<EFPokemonMoveMethods, bool>> predicate);
    }
}