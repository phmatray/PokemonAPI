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
    public class MoveCategoriesService : IMoveCategoriesService
    {
        private readonly VeekunContext _context;

        public MoveCategoriesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.MoveMetaCategories.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFMoveMetaCategories, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .MoveMetaCategories
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<MoveCategory> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<MoveCategory> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<MoveCategory> Get(Expression<Func<EFMoveMetaCategories, bool>> predicate)
        {
            var category = await _context
                .MoveMetaCategories
                .AsNoTracking()
                .Include(x => x.MoveMeta).ThenInclude(x => x.Move)
                .Include(x => x.MoveMetaCategoryProse).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (category == null)
                return null;

            return new MoveCategory
            {
                Id           = category.Id,
                Name         = category.Identifier,
                Moves        = GetMoves(category),
                Descriptions = GetDescriptions(category)
            };
        }

        private static List<NamedAPIResource> GetMoves(EFMoveMetaCategories category)
        {
            return category
                .MoveMeta
                .Select(x => x.Move.ToNamedApiResource())
                .ToList();
        }

        private static List<Description> GetDescriptions(EFMoveMetaCategories category)
        {
            return category
                .MoveMetaCategoryProse
                .Select(x => new Description(x.Description, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}