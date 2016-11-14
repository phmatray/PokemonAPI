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
    public class EncounterMethodsService : IEncounterMethodsService
    {
        private readonly VeekunContext _context;

        public EncounterMethodsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.EncounterMethods.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFEncounterMethods, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .EncounterMethods
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<EncounterMethod> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<EncounterMethod> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<EncounterMethod> Get(Expression<Func<EFEncounterMethods, bool>> predicate)
        {
            var encounterMethod = await _context.EncounterMethods
                .AsNoTracking()
                .Include(x => x.EncounterMethodProse).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (encounterMethod == null)
                return null;

            return new EncounterMethod
            {
                Id    = encounterMethod.Id,
                Name  = encounterMethod.Identifier,
                Order = encounterMethod.Order,
                Names = GetNames(encounterMethod),
            };
        }

        private static List<Name> GetNames(EFEncounterMethods encounterMethod)
        {
            return encounterMethod
                .EncounterMethodProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}