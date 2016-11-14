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
    public class ContestTypesService : IContestTypesService
    {
        private readonly VeekunContext _context;

        public ContestTypesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.ContestTypes.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFContestTypes, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .ContestTypes
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<ContestType> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<ContestType> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<ContestType> Get(Expression<Func<EFContestTypes, bool>> predicate)
        {
            var contestType = await _context.ContestTypes
                .AsNoTracking()
                .Include(x => x.ContestTypeNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.BerryFlavors)
                .FirstOrDefaultAsync(predicate);

            if (contestType == null)
                return null;

            return new ContestType
            {
                Id          = contestType.Id,
                Name        = contestType.Identifier,
                BerryFlavor = GetBerryFlavor(contestType),
                Names       = GetNames(contestType)
            };
        }

        private static NamedAPIResource GetBerryFlavor(EFContestTypes contestType)
        {
            return contestType
                .ContestTypeNames
                .SingleOrDefault(x => x.LocalLanguageId == 9)
                .ToNamedApiResource();
        }

        private static List<ContestName> GetNames(EFContestTypes contestType)
        {
            return contestType
                .ContestTypeNames
                .Where(x => x.Color != null)
                .Select(x => new ContestName(x.Name, x.Color, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}