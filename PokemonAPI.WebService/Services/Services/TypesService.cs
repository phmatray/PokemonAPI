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
using Type = PokemonAPI.Models.Rsc.Type;

namespace PokemonAPI.WebService.Services.Services
{
    public class TypesService : ITypesService
    {
        private readonly VeekunContext _context;

        public TypesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Types.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFTypes, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Types
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Type> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Type> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Type> Get(Expression<Func<EFTypes, bool>> predicate)
        {
            var type = await _context
                .Types
                .AsNoTracking()
                .Include(x => x.TypeEfficacyDamageType).ThenInclude(x => x.TargetType)
                .Include(x => x.TypeEfficacyTargetType).ThenInclude(x => x.DamageType)
                .Include(x => x.TypeGameIndices).ThenInclude(x => x.Generation)
                .Include(x => x.Generation)
                .Include(x => x.DamageClass)
                .Include(x => x.TypeNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.PokemonTypes).ThenInclude(x => x.Pokemon)
                .Include(x => x.Moves)
                .FirstOrDefaultAsync(predicate);

            if (type == null)
                return null;

            return new Type
            {
                Id              = type.Id,
                Name            = type.Identifier,
                DamageRelations = GetDamageRelations(type),
                GameIndices     = GetGameIndices(type),
                Generation      = GetGeneration(type),
                MoveDamageClass = GetMoveDamageClass(type),
                Names           = GetNames(type),
                Pokemon         = GetPokemon(type),
                Moves           = GetMoves(type)
            };
        }

        private static TypeRelations GetDamageRelations(EFTypes type)
        {
            return new TypeRelations
            {
                NoDamageTo       = DamageTo(type, x => x.DamageTypeId == type.Id && x.DamageFactor == 0),
                HalfDamageTo     = DamageTo(type, x => x.DamageTypeId == type.Id && x.DamageFactor == 50),
                NormalDamageTo   = DamageTo(type, x => x.DamageTypeId == type.Id && x.DamageFactor == 100),
                DoubleDamageTo   = DamageTo(type, x => x.DamageTypeId == type.Id && x.DamageFactor == 200),
                NoDamageFrom     = DamageFrom(type, x => x.TargetTypeId == type.Id && x.DamageFactor == 0),
                HalfDamageFrom   = DamageFrom(type, x => x.TargetTypeId == type.Id && x.DamageFactor == 50),
                NormalDamageFrom = DamageFrom(type, x => x.TargetTypeId == type.Id && x.DamageFactor == 100),
                DoubleDamageFrom = DamageFrom(type, x => x.TargetTypeId == type.Id && x.DamageFactor == 200)
            };
        }

        private static List<NamedAPIResource> DamageTo(EFTypes type, Func<EFTypeEfficacy, bool> predicate)
        {
            return type
                .TypeEfficacyDamageType
                .Where(predicate)
                .Select(x => x.TargetType.ToNamedApiResource())
                .ToList();
        }

        private static List<NamedAPIResource> DamageFrom(EFTypes type, Func<EFTypeEfficacy, bool> predicate)
        {
            return type
                .TypeEfficacyTargetType
                .Where(predicate)
                .Select(x => x.DamageType.ToNamedApiResource())
                .ToList();
        }

        private static List<GenerationGameIndex> GetGameIndices(EFTypes type)
        {
            return type
                .TypeGameIndices
                .Select(x => new GenerationGameIndex(x.GameIndex, x.Generation.ToNamedApiResource()))
                .ToList();
        }

        private static NamedAPIResource GetGeneration(EFTypes type)
        {
            return type
                .Generation
                .ToNamedApiResource();
        }

        private static NamedAPIResource GetMoveDamageClass(EFTypes type)
        {
            return type
                .DamageClass
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFTypes type)
        {
            return type
                .TypeNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<TypePokemon> GetPokemon(EFTypes type)
        {
            return type
                .PokemonTypes
                .Select(x => new TypePokemon(x.Slot, x.Pokemon.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetMoves(EFTypes type)
        {
            return type
                .Moves
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }
    }
}