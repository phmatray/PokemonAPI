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
    public class EncounterConditionValuesService : IEncounterConditionValuesService
    {
        private readonly VeekunContext _context;

        public EncounterConditionValuesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.EncounterConditionValues.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFEncounterConditionValues, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .EncounterConditionValues
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<EncounterConditionValue> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<EncounterConditionValue> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<EncounterConditionValue> Get(Expression<Func<EFEncounterConditionValues, bool>> predicate)
        {
            var encounterConditionValue = await _context.EncounterConditionValues
                .AsNoTracking()
                .Include(x => x.EncounterCondition)
                .Include(x => x.EncounterConditionValueProse).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (encounterConditionValue == null)
                return null;

            return new EncounterConditionValue
            {
                Id        = encounterConditionValue.Id,
                Name      = encounterConditionValue.Identifier,
                Condition = GetCondition(encounterConditionValue),
                Names     = GetNames(encounterConditionValue),
            };
        }

        private static NamedAPIResource GetCondition(EFEncounterConditionValues encounterConditionValue)
        {
            return encounterConditionValue
                .EncounterCondition
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFEncounterConditionValues encounterConditionValue)
        {
            return encounterConditionValue
                .EncounterConditionValueProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}