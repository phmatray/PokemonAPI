using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IPokeathlonStatsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokeathlonStats, bool>> predicate, int limit, int offset);
        Task<PokeathlonStat> Get(int id);
        Task<PokeathlonStat> Get(string name);
        Task<PokeathlonStat> Get(Expression<Func<EFPokeathlonStats, bool>> predicate);
    }
}