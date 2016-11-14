using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Type = PokemonAPI.Models.Rsc.Type;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface ITypesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFTypes, bool>> predicate, int limit, int offset);
        Task<Type> Get(int id);
        Task<Type> Get(string name);
        Task<Type> Get(Expression<Func<EFTypes, bool>> predicate);
    }
}