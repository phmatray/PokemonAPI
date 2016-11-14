using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IEggGroupsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFEggGroups, bool>> predicate, int limit, int offset);
        Task<EggGroup> Get(int id);
        Task<EggGroup> Get(string name);
        Task<EggGroup> Get(Expression<Func<EFEggGroups, bool>> predicate);
    }
}