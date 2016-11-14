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
    public class BerriesService : IBerriesService
    {
        private readonly VeekunContext _context;

        public BerriesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Berries.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFBerries, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Berries
                .AsNoTracking()
                .Include(x => x.Item)
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Berry> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Berry> Get(string name)
        {
            return await Get(x => x.Item.Identifier.Replace("-berry", "") == name);
        }

        public async Task<Berry> Get(Expression<Func<EFBerries, bool>> predicate)
        {
            var berry = await _context.Berries
                .AsNoTracking()
                .Include(x => x.Firmness)
                .Include(x => x.BerryFlavors).ThenInclude(x => x.ContestType).ThenInclude(x => x.ContestTypeNames)
                .Include(x => x.Item)
                .Include(x => x.NaturalGiftType)
                .FirstOrDefaultAsync(predicate);

            if (berry == null)
                return null;

            return new Berry
            {
                Id               = berry.Id,
                Name             = berry.Item.Identifier.Replace("-berry", ""),
                GrowthTime       = berry.GrowthTime,
                MaxHarvest       = berry.MaxHarvest,
                NaturalGiftPower = berry.NaturalGiftPower,
                Size             = berry.Size,
                Smoothness       = berry.Smoothness,
                SoilDryness      = berry.SoilDryness,
                Firmness         = GetFirmness(berry),
                Flavors          = GetFlavors(berry),
                Item             = GetItem(berry),
                NaturalGiftType  = GetNaturalGiftType(berry)
            };
        }

        private static NamedAPIResource GetFirmness(EFBerries berry)
        {
            return berry
                .Firmness?
                .ToNamedApiResource();
        }

        private static List<BerryFlavorMap> GetFlavors(EFBerries berry)
        {
            return berry
                .BerryFlavors
                .Select(x => new BerryFlavorMap
                {
                    Potency = x.Flavor,
                    Flavor = new NamedAPIResource
                    (
                        x.ContestType.ContestTypeNames.Single(y => y.LocalLanguageId == 9).Flavor.ToLower(),
                        typeof(BerryFlavorsController).RscUrl(x.ContestTypeId)
                    )
                })
                .ToList();
        }

        private static NamedAPIResource GetItem(EFBerries berry)
        {
            return berry
                .Item?
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetNaturalGiftType(EFBerries berry)
        {
            return berry
                .NaturalGiftType?
                .ToNamedApiResource();
        }
    }
}