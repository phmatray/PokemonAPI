using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IItemAttributesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFItemFlags, bool>> predicate, int limit, int offset);
        Task<ItemAttribute> Get(int id);
        Task<ItemAttribute> Get(string name);
        Task<ItemAttribute> Get(Expression<Func<EFItemFlags, bool>> predicate);
    }
}