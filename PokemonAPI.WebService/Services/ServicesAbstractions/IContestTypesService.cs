using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IContestTypesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFContestTypes, bool>> predicate, int limit, int offset);
        Task<ContestType> Get(int id);
        Task<ContestType> Get(string name);
        Task<ContestType> Get(Expression<Func<EFContestTypes, bool>> predicate);
    }
}