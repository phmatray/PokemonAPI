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
using Version = PokemonAPI.Models.Rsc.Version;

namespace PokemonAPI.WebService.Services.Services
{
    public class VersionsService : IVersionsService
    {
        private readonly VeekunContext _context;

        public VersionsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Versions.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFVersions, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Versions
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Version> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Version> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Version> Get(Expression<Func<EFVersions, bool>> predicate)
        {
            var version = await _context.Versions
                .AsNoTracking()
                .Include(x => x.VersionNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.VersionGroup)
                .FirstOrDefaultAsync(predicate);

            if (version == null)
                return null;

            return new Version
            {
                Id           = version.Id,
                Name         = version.Identifier,
                Names        = GetNames(version),
                VersionGroup = GetVersionGroup(version)
            };
        }

        private static List<Name> GetNames(EFVersions version)
        {
            return version
                .VersionNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static NamedAPIResource GetVersionGroup(EFVersions version)
        {
            return version
                .VersionGroup?
                .ToNamedApiResource();
        }
    }
}