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
    public class PokeathlonStatsService : IPokeathlonStatsService
    {
        private readonly VeekunContext _context;

        public PokeathlonStatsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.PokeathlonStats.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokeathlonStats, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .PokeathlonStats
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<PokeathlonStat> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<PokeathlonStat> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<PokeathlonStat> Get(Expression<Func<EFPokeathlonStats, bool>> predicate)
        {
            var pokeathlonStat = await _context
                .PokeathlonStats
                .AsNoTracking()
                .Include(x => x.NaturePokeathlonStats).ThenInclude(x => x.Nature)
                .Include(x => x.PokeathlonStatNames).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (pokeathlonStat == null)
                return null;

            return new PokeathlonStat
            {
                Id               = pokeathlonStat.Id,
                Name             = pokeathlonStat.Identifier,
                Names            = GetNames(pokeathlonStat),
                AffectingNatures = GetAffectingNatures(pokeathlonStat)
            };
        }

        private static List<Name> GetNames(EFPokeathlonStats pokeathlonStat)
        {
            return pokeathlonStat
                .PokeathlonStatNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static NaturePokeathlonStatAffectSets GetAffectingNatures(EFPokeathlonStats pokeathlonStat)
        {
            return new NaturePokeathlonStatAffectSets
            {
                Increase = pokeathlonStat
                    .NaturePokeathlonStats
                    .Where(x => x.MaxChange > 0)
                    .Select(x => new NaturePokeathlonStatAffect(x.MaxChange, x.Nature.ToNamedApiResource()))
                    .ToList(),
                Decrease = pokeathlonStat
                    .NaturePokeathlonStats
                    .Where(x => x.MaxChange < 0)
                    .Select(x => new NaturePokeathlonStatAffect(x.MaxChange, x.Nature.ToNamedApiResource()))
                    .ToList()
            };
        }
    }
}