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
    public class BerryFirmnessesService : IBerryFirmnessesService
    {
        private readonly VeekunContext _context;

        public BerryFirmnessesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.BerryFirmness.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFBerryFirmness, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .BerryFirmness
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<BerryFirmness> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<BerryFirmness> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<BerryFirmness> Get(Expression<Func<EFBerryFirmness, bool>> predicate)
        {
            var berryFirmness = await _context.BerryFirmness
                .AsNoTracking()
                .Include(x => x.Berries).ThenInclude(x => x.Item)
                .Include(x => x.BerryFirmnessNames).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (berryFirmness == null)
                return null;

            return new BerryFirmness
            {
                Id      = berryFirmness.Id,
                Name    = berryFirmness.Identifier,
                Berries = GetBerries(berryFirmness),
                Names   = GetNames(berryFirmness)
            };
        }

        private static List<NamedAPIResource> GetBerries(EFBerryFirmness berryFirmness)
        {
            return berryFirmness
                .Berries
                .Select(x => new NamedAPIResource
                (
                    x.Item.Identifier.Replace("-berry", ""),
                    typeof(BerriesController).RscUrl(x.Id)
                ))
                .ToList();
        }

        private static List<Name> GetNames(EFBerryFirmness berryFirmness)
        {
            return berryFirmness
                .BerryFirmnessNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}