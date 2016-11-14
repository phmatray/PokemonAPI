using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IItemCategoriesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFItemCategories, bool>> predicate, int limit, int offset);
        Task<ItemCategory> Get(int id);
        Task<ItemCategory> Get(string name);
        Task<ItemCategory> Get(Expression<Func<EFItemCategories, bool>> predicate);
    }
}