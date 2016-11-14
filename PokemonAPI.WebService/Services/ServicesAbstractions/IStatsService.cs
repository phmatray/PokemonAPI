using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IStatsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFStats, bool>> predicate, int limit, int offset);
        Task<Stat> Get(int id);
        Task<Stat> Get(string name);
        Task<Stat> Get(Expression<Func<EFStats, bool>> predicate);
    }
}