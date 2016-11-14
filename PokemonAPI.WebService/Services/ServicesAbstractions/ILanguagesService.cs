using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface ILanguagesService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFLanguages, bool>> predicate, int limit, int offset);
        Task<Language> Get(int id);
        Task<Language> Get(string name);
        Task<Language> Get(Expression<Func<EFLanguages, bool>> predicate);
    }
}