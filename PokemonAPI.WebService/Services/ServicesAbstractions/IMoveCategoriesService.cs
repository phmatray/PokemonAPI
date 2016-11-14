using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IMoveCategoriesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveMetaCategories, bool>> predicate, int limit, int offset);
        Task<MoveCategory> Get(int id);
        Task<MoveCategory> Get(string name);
        Task<MoveCategory> Get(Expression<Func<EFMoveMetaCategories, bool>> predicate);
    }
}