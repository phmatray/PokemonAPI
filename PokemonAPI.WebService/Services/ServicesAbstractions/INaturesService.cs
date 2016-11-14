using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface INaturesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFNatures, bool>> predicate, int limit, int offset);
        Task<Nature> Get(int id);
        Task<Nature> Get(string name);
        Task<Nature> Get(Expression<Func<EFNatures, bool>> predicate);
    }
}