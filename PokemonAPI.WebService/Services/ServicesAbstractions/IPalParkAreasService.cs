using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IPalParkAreasService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPalParkAreas, bool>> predicate, int limit, int offset);
        Task<PalParkArea> Get(int id);
        Task<PalParkArea> Get(string name);
        Task<PalParkArea> Get(Expression<Func<EFPalParkAreas, bool>> predicate);
    }
}