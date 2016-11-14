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
    public class MoveLearnMethodsService : IMoveLearnMethodsService
    {
        private readonly VeekunContext _context;

        public MoveLearnMethodsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.PokemonMoveMethods.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonMoveMethods, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .PokemonMoveMethods
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<MoveLearnMethod> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<MoveLearnMethod> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<MoveLearnMethod> Get(Expression<Func<EFPokemonMoveMethods, bool>> predicate)
        {
            var moveMethod = await _context
                .PokemonMoveMethods
                .AsNoTracking()
                .Include(x => x.PokemonMoveMethodProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.VersionGroupPokemonMoveMethods).ThenInclude(x => x.VersionGroup)
                .FirstOrDefaultAsync(predicate);

            if (moveMethod == null)
                return null;

            return new MoveLearnMethod
            {
                Id            = moveMethod.Id,
                Name          = moveMethod.Identifier,
                Descriptions  = GetDescriptions(moveMethod),
                Names         = GetNames(moveMethod),
                VersionGroups = GetVersionGroups(moveMethod)
            };
        }

        private static List<Description> GetDescriptions(EFPokemonMoveMethods moveMethod)
        {
            return moveMethod
                .PokemonMoveMethodProse
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<Name> GetNames(EFPokemonMoveMethods moveMethod)
        {
            return moveMethod
                .PokemonMoveMethodProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetVersionGroups(EFPokemonMoveMethods moveMethod)
        {
            return moveMethod
                .VersionGroupPokemonMoveMethods
                .Select(x => x.VersionGroup.ToNamedApiResource())
                .ToList();
        }
    }
}