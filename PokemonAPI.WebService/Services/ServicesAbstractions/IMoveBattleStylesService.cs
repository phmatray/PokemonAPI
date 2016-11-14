using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IMoveBattleStylesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveBattleStyles, bool>> predicate, int limit, int offset);
        Task<MoveBattleStyle> Get(int id);
        Task<MoveBattleStyle> Get(string name);
        Task<MoveBattleStyle> Get(Expression<Func<EFMoveBattleStyles, bool>> predicate);
    }
}