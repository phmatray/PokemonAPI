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
    public class AbilitiesService : IAbilitiesService
    {
        private readonly VeekunContext _context;

        public AbilitiesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Abilities.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFAbilities, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Abilities
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Ability> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Ability> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Ability> Get(Expression<Func<EFAbilities, bool>> predicate)
        {
            var ability = await _context
                .Abilities
                .AsNoTracking()
                .Include(x => x.Generation)
                .Include(x => x.AbilityNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.AbilityProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.AbilityChangelog).ThenInclude(x => x.AbilityChangelogProse)
                .Include(x => x.AbilityChangelog).ThenInclude(x => x.ChangedInVersionGroup)
                .Include(x => x.AbilityFlavorText).ThenInclude(x => x.Language)
                .Include(x => x.AbilityFlavorText).ThenInclude(x => x.VersionGroup)
                .Include(x => x.PokemonAbilities).ThenInclude(x => x.Pokemon)
                .FirstOrDefaultAsync(predicate);

            if (ability == null)
                return null;

            return new Ability
            {
                Id                = ability.Id,
                Name              = ability.Identifier,
                IsMainSeries      = ability.IsMainSeries,
                Generation        = GetGeneration(ability),
                Names             = GetNames(ability),
                EffectEntries     = GetEffectEntries(ability),
                EffectChanges     = GetEffectChanges(ability),
                FlavorTextEntries = GetFlavorTextEntries(ability),
                Pokemon           = GetPokemon(ability)
            };
        }

        private static NamedAPIResource GetGeneration(EFAbilities ability)
        {
            return ability
                .Generation?
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFAbilities ability)
        {
            return ability
                .AbilityNames?
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<VerboseEffect> GetEffectEntries(EFAbilities ability)
        {
            return ability
                .AbilityProse?
                .Select(x => new VerboseEffect(x.Effect, x.ShortEffect, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<AbilityEffectChange> GetEffectChanges(EFAbilities ability)
        {
            return ability
                .AbilityChangelog?
                .Select(x =>
                {
                    var effectEntries1 = x.AbilityChangelogProse?
                        .Select(y => new Effect(y.Effect, y.LocalLanguage?.ToNamedApiResource()))
                        .ToList();

                    return new AbilityEffectChange(effectEntries1, x.ChangedInVersionGroup?.ToNamedApiResource());
                })
                .ToList();
        }

        private static List<AbilityFlavorText> GetFlavorTextEntries(EFAbilities ability)
        {
            return ability
                .AbilityFlavorText?
                .Select(x => new AbilityFlavorText(x.FlavorText,
                    x.Language.ToNamedApiResource(), x.VersionGroup.ToNamedApiResource()))
                .ToList();
        }

        private static List<AbilityPokemon> GetPokemon(EFAbilities ability)
        {
            return ability
                .PokemonAbilities?
                .Select(x => new AbilityPokemon(x.IsHidden, x.Slot, x.Pokemon.ToNamedApiResource()))
                .ToList();
        }
    }
}