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
    public class GrowthRatesService : IGrowthRatesService
    {
        private readonly VeekunContext _context;

        public GrowthRatesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.GrowthRates.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFGrowthRates, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .GrowthRates
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<GrowthRate> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<GrowthRate> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<GrowthRate> Get(Expression<Func<EFGrowthRates, bool>> predicate)
        {
            var growthRate = await _context
                .GrowthRates
                .AsNoTracking()
                .Include(x => x.GrowthRateProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.Experience)
                .Include(x => x.PokemonSpecies)
                .FirstOrDefaultAsync(predicate);

            if (growthRate == null)
                return null;

            return new GrowthRate
            {
                Id             = growthRate.Id,
                Name           = growthRate.Identifier,
                Formula        = growthRate.Formula,
                Descriptions   = GetDescriptions(growthRate),
                Levels         = GetLevels(growthRate),
                PokemonSpecies = GetPokemonSpecies(growthRate)
            };
        }

        private static List<Description> GetDescriptions(EFGrowthRates growthRate)
        {
            return growthRate
                .GrowthRateProse
                .Select(x => new Description(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<GrowthRateExperienceLevel> GetLevels(EFGrowthRates growthRate)
        {
            return growthRate
                .Experience
                .Select(x => new GrowthRateExperienceLevel(x.Level, x.Experience1))
                .ToList();
        }

        private static List<NamedAPIResource> GetPokemonSpecies(EFGrowthRates growthRate)
        {
            return growthRate
                .PokemonSpecies
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}