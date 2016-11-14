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
    public class ItemsService : IItemsService
    {
        private readonly VeekunContext _context;

        public ItemsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Items.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFItems, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Items
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Item> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Item> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Item> Get(Expression<Func<EFItems, bool>> predicate)
        {
            var item = await _context.Items
                .AsNoTracking()
                .Include(x => x.FlingEffect)
                .Include(x => x.ItemFlagMap).ThenInclude(x => x.ItemFlag)
                .Include(x => x.Category).ThenInclude(x => x.Items)
                .Include(x => x.Category).ThenInclude(x => x.ItemCategoryProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.Category).ThenInclude(x => x.Pocket)
                .Include(x => x.ItemProse).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.ItemFlavorText).ThenInclude(x => x.Language)
                .Include(x => x.ItemFlavorText).ThenInclude(x => x.VersionGroup)
                .Include(x => x.ItemGameIndices).ThenInclude(x => x.Generation)
                .Include(x => x.ItemNames).ThenInclude(x => x.LocalLanguage)
                .Include(x => x.PokemonItems).ThenInclude(x => x.Pokemon)
                .Include(x => x.PokemonItems).ThenInclude(x => x.Version)
                .Include(x => x.Machines).ThenInclude(x => x.VersionGroup)
                .FirstOrDefaultAsync(predicate);

            if (item == null)
                return null;

            return new Item
            {
                Id                = item.Id,
                Name              = item.Identifier,
                Cost              = item.Cost,
                FlingPower        = item.FlingPower,
                FlingEffect       = GetFlingEffect(item),
                Attributes        = GetAttributes(item),
                Category          = GetCategory(item),
                EffectEntries     = GetEffectEntries(item),
                FlavorTextEntries = GetFlavorTextEntries(item),
                GameIndices       = GetGameIndices(item),
                Names             = GetNames(item),
                Sprites           = null, //GetSprites(item),
                HeldByPokemon     = GetHeldByPokemon(item),
                BabyTriggerFor    = GetBabyTriggerFor(item),
                Machines          = GetMachines(item)
            };
        }

        private static NamedAPIResource GetFlingEffect(EFItems item)
        {
            return item
                .FlingEffect?
                .ToNamedApiResource();
        }

        private static List<NamedAPIResource> GetAttributes(EFItems item)
        {
            return item
                .ItemFlagMap
                .Select(x => x.ItemFlag.ToNamedApiResource())
                .ToList();
        }

        private static NamedAPIResource GetCategory(EFItems item)
        {
            return item
                .Category?
                .ToNamedApiResource();
        }

        private static List<VerboseEffect> GetEffectEntries(EFItems item)
        {
            return item
                .ItemProse
                .Select(x => new VerboseEffect(x.Effect, x.ShortEffect, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<VersionGroupFlavorText> GetFlavorTextEntries(EFItems item)
        {
            return item
                .ItemFlavorText
                .Select(x => new VersionGroupFlavorText(x.FlavorText,
                    x.Language.ToNamedApiResource(), x.VersionGroup.ToNamedApiResource()))
                .ToList();
        }

        private static List<GenerationGameIndex> GetGameIndices(EFItems item)
        {
            return item
                .ItemGameIndices
                .Select(x => new GenerationGameIndex(x.GameIndex, x.Generation.ToNamedApiResource()))
                .ToList();
        }

        private static List<Name> GetNames(EFItems item)
        {
            return item
                .ItemNames
                .Select(x => new Name(x.Name, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        //private static ItemSprites GetSprites(EFItems item)
        //{
        //    return new ItemSprites
        //    {
        //        Default = null //TODO: Get Sprites
        //    };
        //}

        private static List<ItemHolderPokemon> GetHeldByPokemon(EFItems item)
        {
            return item
                .PokemonItems
                .GroupBy(x => x.PokemonId, (key, group) =>
                {
                    var efPokemonItemses = group as IList<EFPokemonItems> ?? group.ToList();

                    return new ItemHolderPokemon
                    {
                        Pokemon = efPokemonItemses
                            .FirstOrDefault()?
                            .Pokemon
                            .ToNamedApiResource(),
                        VersionDetails = efPokemonItemses
                            .Select(g => new ItemHolderPokemonVersionDetail
                            {
                                Rarity = g.Rarity,
                                Version = g.Version?.ToNamedApiResource()
                            })
                            .ToList()
                    };
                })
                .ToList();
        }

        private APIResource GetBabyTriggerFor(EFItems item)
        {
            return _context
                .EvolutionChains
                .SingleOrDefault(x => x.BabyTriggerItemId == item.Id)?
                .ToApiResource();
        }

        private static List<MachineVersionDetail> GetMachines(EFItems item)
        {
            return item
                .Machines
                .Select(x => new MachineVersionDetail(x.ToApiResource(), x.VersionGroup.ToNamedApiResource()))
                .ToList();
        }
    }
}