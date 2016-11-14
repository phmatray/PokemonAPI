using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IItemsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFItems, bool>> predicate, int limit, int offset);
        Task<Item> Get(int id);
        Task<Item> Get(string name);
        Task<Item> Get(Expression<Func<EFItems, bool>> predicate);
    }
}