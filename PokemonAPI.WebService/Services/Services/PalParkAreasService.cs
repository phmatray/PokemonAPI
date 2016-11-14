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
    public class PalParkAreasService : IPalParkAreasService
    {
        private readonly VeekunContext _context;

        public PalParkAreasService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.PalParkAreas.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPalParkAreas, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .PalParkAreas
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<PalParkArea> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<PalParkArea> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<PalParkArea> Get(Expression<Func<EFPalParkAreas, bool>> predicate)
        {
            var palParkArea = await _context.PalParkAreas
                .AsNoTracking()
                .Include(x => x.PalParkAreaNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.PalPark).ThenInclude(x => x.Species)
                .FirstOrDefaultAsync(predicate);

            if (palParkArea == null)
                return null;

            return new PalParkArea
            {
                Id                = palParkArea.Id,
                Name              = palParkArea.Identifier,
                Names             = GetNames(palParkArea),
                PokemonEncounters = GetPokemonEncounters(palParkArea)
            };
        }

        private static List<Name> GetNames(EFPalParkAreas palParkArea)
        {
            return palParkArea
                .PalParkAreaNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<PalParkEncounterSpecies> GetPokemonEncounters(EFPalParkAreas palParkArea)
        {
            return palParkArea
                .PalPark
                .Select(x => new PalParkEncounterSpecies(x.BaseScore, x.Rate, x.Species.ToNamedApiResource()))
                .ToList();
        }
    }
}