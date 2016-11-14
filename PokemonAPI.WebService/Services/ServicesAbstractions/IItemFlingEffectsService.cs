using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IItemFlingEffectsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFItemFlingEffects, bool>> predicate, int limit, int offset);
        Task<ItemFlingEffect> Get(int id);
        Task<ItemFlingEffect> Get(string name);
        Task<ItemFlingEffect> Get(Expression<Func<EFItemFlingEffects, bool>> predicate);
    }
}