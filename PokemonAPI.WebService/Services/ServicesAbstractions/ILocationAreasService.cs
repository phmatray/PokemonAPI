using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface ILocationAreasService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFLocationAreas, bool>> predicate, int limit, int offset);
        Task<LocationArea> Get(int id);
        Task<LocationArea> Get(string name);
        Task<LocationArea> Get(Expression<Func<EFLocationAreas, bool>> predicate);
    }
}