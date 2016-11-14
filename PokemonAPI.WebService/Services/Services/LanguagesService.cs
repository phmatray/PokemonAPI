using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.Services
{
    public class LanguagesService : ILanguagesService
    {
        private readonly VeekunContext _context;

        public LanguagesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Languages.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFLanguages, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Languages
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Language> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Language> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Language> Get(Expression<Func<EFLanguages, bool>> predicate)
        {
            var language = await _context
                .Languages
                .AsNoTracking()
                .Include(x => x.LanguageNamesLanguage).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (language == null)
                return null;

            return new Language
            {
                Id       = language.Id,
                Name     = language.Identifier,
                Iso639   = language.Iso639,
                Iso3166  = language.Iso3166,
                Official = language.Official,
                Names    = GetNames(language)
            };
        }

        private static List<Name> GetNames(EFLanguages language)
        {
            return language
                .LanguageNamesLanguage
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}