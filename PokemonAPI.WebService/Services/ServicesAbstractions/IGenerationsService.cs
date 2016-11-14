using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IGenerationsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFGenerations, bool>> predicate, int limit, int offset);
        Task<Generation> Get(int id);
        Task<Generation> Get(string name);
        Task<Generation> Get(Expression<Func<EFGenerations, bool>> predicate);
    }
}