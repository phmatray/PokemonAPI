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
    public class CharacteristicsService : ICharacteristicsService
    {
        private readonly VeekunContext _context;

        public CharacteristicsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Characteristics.CountAsync();
        }

        public async Task<List<APIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<APIResource>> GetAll(Expression<Func<EFCharacteristics, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Characteristics
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Characteristic> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Characteristic> Get(Expression<Func<EFCharacteristics, bool>> predicate)
        {
            var characteristic = await _context
                .Characteristics
                .AsNoTracking()
                .Include(x => x.Stat)
                .Include(x => x.CharacteristicText).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (characteristic == null)
                return null;

            return new Characteristic
            {
                Id             = characteristic.Id,
                GeneModulo     = characteristic.GeneMod5,
                HighestStat    = GetHighestStat(characteristic),
                PossibleValues = GetPossibleValues(characteristic),
                Descriptions   = GetDescriptions(characteristic)
            };
        }

        private static NamedAPIResource GetHighestStat(EFCharacteristics characteristic)
        {
            return characteristic.Stat?.ToNamedApiResource();
        }

        private static List<int> GetPossibleValues(EFCharacteristics characteristic)
        {
            switch (characteristic.GeneMod5)
            {
                case 0: return new List<int> {0, 5, 10, 15, 20, 25, 30};
                case 1: return new List<int> {1, 6, 11, 16, 21, 26, 31};
                case 2: return new List<int> {2, 7, 12, 17, 22, 27};
                case 3: return new List<int> {3, 8, 13, 18, 23, 28};
                case 4: return new List<int> {4, 9, 14, 19, 24, 29};
                default:
                    return null;
            }
        }

        private static List<Description> GetDescriptions(EFCharacteristics characteristic)
        {
            return characteristic
                .CharacteristicText
                .Select(x => new Description(x.Message, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}