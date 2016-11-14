using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.Services
{
    public class BerryFlavorsService : IBerryFlavorsService
    {
        private readonly VeekunContext _context;

        public BerryFlavorsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.BerryFlavors.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFContestTypeNames, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .ContestTypeNames
                .AsNoTracking()
                .Where(predicate)
                .Where(x => x.LocalLanguageId == 9)
                .OrderBy(x => x.ContestTypeId)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<BerryFlavor> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<BerryFlavor> Get(string name)
        {
            return await Get(x => x.ContestTypeNames
                                      .FirstOrDefault(y => y.LocalLanguageId == 9)
                                      .Flavor
                                      .ToLower() == name);
        }

        public async Task<BerryFlavor> Get(Expression<Func<EFContestTypes, bool>> predicate)
        {
            var contestType = await _context
                .ContestTypes
                .AsNoTracking()
                .Include(x => x.ContestTypeNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.BerryFlavors).ThenInclude(x => x.Berry).ThenInclude(x => x.Item)
                .Where(predicate)
                .FirstOrDefaultAsync();

            if (contestType == null)
                return null;

            return new BerryFlavor
            {
                Id          = contestType.Id,
                Name        = GetName(contestType),
                Berries     = GetBerries(contestType),
                ContestType = GetContestType(contestType),
                Names       = GetNames(contestType)
            };
        }

        private static string GetName(EFContestTypes contestType)
        {
            return contestType
                .ContestTypeNames
                .FirstOrDefault(x => x.LocalLanguageId == 9)?
                .Flavor
                .ToLower();
        }

        private static List<FlavorBerryMap> GetBerries(EFContestTypes contestType)
        {
            return contestType
                .BerryFlavors
                .Where(x => x.Flavor > 0)
                .OrderBy(x => x.Flavor)
                .Select(x => new FlavorBerryMap
                {
                    Potency = x.Flavor,
                    Berry = new NamedAPIResource
                    (
                        x.Berry.Item.Identifier.Replace("-berry", ""),
                        typeof(BerriesController).RscUrl(x.BerryId)
                    )
                })
                .ToList();
        }

        private static NamedAPIResource GetContestType(EFContestTypes contestType)
        {
            return contestType.ToNamedApiResource();
        }

        private static List<Name> GetNames(EFContestTypes contestType)
        {
            return contestType
                .ContestTypeNames
                .Select(x => new Name(x.Flavor, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}