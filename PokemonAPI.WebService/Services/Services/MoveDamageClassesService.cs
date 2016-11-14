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
    public class MoveDamageClassesService : IMoveDamageClassesService
    {
        private readonly VeekunContext _context;

        public MoveDamageClassesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.MoveDamageClasses.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveDamageClasses, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .MoveDamageClasses
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<MoveDamageClass> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<MoveDamageClass> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<MoveDamageClass> Get(Expression<Func<EFMoveDamageClasses, bool>> predicate)
        {
            var moveDamageClass = await _context
                .MoveDamageClasses
                .AsNoTracking()
                .Include(x => x.MoveDamageClassProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.Moves)
                .FirstOrDefaultAsync(predicate);

            if (moveDamageClass == null)
                return null;

            return new MoveDamageClass
            {
                Id           = moveDamageClass.Id,
                Name         = moveDamageClass.Identifier,
                Descriptions = GetDescriptions(moveDamageClass),
                Moves        = GetMoves(moveDamageClass),
                Names        = GetNames(moveDamageClass)
            };
        }

        private static List<Description> GetDescriptions(EFMoveDamageClasses moveDamageClass)
        {
            return moveDamageClass
                .MoveDamageClassProse
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetMoves(EFMoveDamageClasses moveDamageClass)
        {
            return moveDamageClass
                .Moves
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<Name> GetNames(EFMoveDamageClasses moveDamageClass)
        {
            return moveDamageClass
                .MoveDamageClassProse
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}