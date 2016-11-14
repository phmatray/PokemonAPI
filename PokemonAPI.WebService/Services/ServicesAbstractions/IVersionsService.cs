using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;
using Version = PokemonAPI.Models.Rsc.Version;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IVersionsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFVersions, bool>> predicate, int limit, int offset);
        Task<Version> Get(int id);
        Task<Version> Get(string name);
        Task<Version> Get(Expression<Func<EFVersions, bool>> predicate);
    }
}