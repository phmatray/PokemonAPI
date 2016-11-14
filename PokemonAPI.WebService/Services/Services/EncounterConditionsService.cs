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
    public class EncounterConditionsService : IEncounterConditionsService
    {
        private readonly VeekunContext _context;

        public EncounterConditionsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.EncounterConditions.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFEncounterConditions, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .EncounterConditions
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<EncounterCondition> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<EncounterCondition> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<EncounterCondition> Get(Expression<Func<EFEncounterConditions, bool>> predicate)
        {
            var encounterCondition = await _context.EncounterConditions
                .AsNoTracking()
                .Include(x => x.EncounterConditionProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.EncounterConditionValues)
                .FirstOrDefaultAsync(predicate);

            if (encounterCondition == null)
                return null;

            return new EncounterCondition
            {
                Id     = encounterCondition.Id,
                Name   = encounterCondition.Identifier,
                Names  = GetNames(encounterCondition),
                Values = GetValues(encounterCondition)
            };
        }

        private static List<Name> GetNames(EFEncounterConditions encounterCondition)
        {
            return encounterCondition
                .EncounterConditionProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetValues(EFEncounterConditions encounterCondition)
        {
            return encounterCondition
                .EncounterConditionValues
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}