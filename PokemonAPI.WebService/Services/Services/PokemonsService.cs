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
    public class PokemonsService : IPokemonsService
    {
        private readonly VeekunContext _context;

        public PokemonsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Pokemon.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemon, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Pokemon
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        //public async Task<string> GetAllDetails()
        //{
        //    var pokemons = await _context
        //        .Pokemon
        //        .AsNoTracking()
        //        .Include(x => x.Species).ThenInclude(x => x.PokemonEggGroups)
        //        .Include(x => x.PokemonStats).ThenInclude(x => x.Stat)
        //        .Select(x => new
        //        {
        //            Name      = x.Identifier,
        //            Gender    = x.Species.GenderRate,
        //            EggGroups = x.Species.PokemonEggGroups,
        //            Types     = x.PokemonTypes,
        //            Stats     = GetStats(x)
        //        })
        //        .ToListAsync();

        //    return pokemons.ToJson();
        //}

        public async Task<Pokemon> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Pokemon> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Pokemon> Get(Expression<Func<EFPokemon, bool>> predicate)
        {
            var pokemon = await _context
                .Pokemon
                .AsNoTracking()
                .Include(x => x.PokemonAbilities).ThenInclude(x => x.Ability)
                .Include(x => x.PokemonForms)
                .Include(x => x.PokemonGameIndices).ThenInclude(x => x.Version)
                .Include(x => x.PokemonItems).ThenInclude(x => x.Item)
                .Include(x => x.PokemonItems).ThenInclude(x => x.Version)
                .Include(x => x.PokemonMoves).ThenInclude(x => x.Move)
                .Include(x => x.PokemonMoves).ThenInclude(x => x.VersionGroup)
                .Include(x => x.PokemonMoves).ThenInclude(x => x.PokemonMoveMethod)
                .Include(x => x.Species)
                .Include(x => x.PokemonStats).ThenInclude(x => x.Stat)
                .Include(x => x.PokemonTypes).ThenInclude(x => x.Type)
                .FirstOrDefaultAsync(predicate);

            if (pokemon == null)
                return null;

            return new Pokemon
            {
                Id                     = pokemon.Id,
                Name                   = pokemon.Identifier,
                BaseExperience         = pokemon.BaseExperience,
                Height                 = pokemon.Height,
                IsDefault              = pokemon.IsDefault,
                Order                  = pokemon.Order,
                Weight                 = pokemon.Weight,
                Abilities              = GetAbilities(pokemon),
                Forms                  = GetForms(pokemon),
                GameIndices            = GetGameIndices(pokemon),
                HeldItems              = GetHeldItems(pokemon),
                LocationAreaEncounters = GetLocationAreaEncounters(pokemon),
                Moves                  = GetMoves(pokemon),
                Sprites                = null, //GetSprites(pokemon),
                Species                = GetSpecies(pokemon),
                Stats                  = GetStats(pokemon),
                Types                  = GetTypes(pokemon)
            };
        }

        public async Task<List<LocationAreaEncounter>> GetEncounters(int pokemonId)
        {
            return await GetEncounters(x => x.PokemonId == pokemonId);
        }

        public async Task<List<LocationAreaEncounter>> GetEncounters(string pokemonName)
        {
            return await GetEncounters(x => x.Pokemon.Identifier == pokemonName);
        }

        public async Task<List<LocationAreaEncounter>> GetEncounters(Expression<Func<EFEncounters, bool>> predicate)
        {
            var efEncounterses = await _context
                .Encounters
                .AsNoTracking()
                .Include(x => x.LocationArea).ThenInclude(x => x.Location)
                .Include(x => x.Version)
                .Include(x => x.EncounterConditionValueMap).ThenInclude(x => x.EncounterConditionValue)
                .Include(x => x.EncounterSlot).ThenInclude(x => x.EncounterMethod)
                .Include(x => x.Pokemon)
                .Where(predicate)
                .ToListAsync();

            return efEncounterses
                .GroupBy(x => x.LocationAreaId, (locationAreaId, encountersG1) =>
                {
                    var locationArea = encountersG1.FirstOrDefault()?.LocationArea?.ToNamedApiResource();
                    var versionDetails = encountersG1?
                        .GroupBy(x => x.VersionId, (versionId, encountersG2) =>
                        {
                            var version = encountersG2?.FirstOrDefault().Version.ToNamedApiResource();
                            var maxChance = encountersG2?.Sum(enc => enc.EncounterSlot.Rarity ?? 0) ?? 0;
                            var encounterDetails = encountersG2?
                                .Select(enc => new Encounter(
                                    enc.MinLevel,
                                    enc.MaxLevel,
                                    enc.EncounterConditionValueMap?
                                        .Select(ecvm => ecvm.EncounterConditionValue?.ToNamedApiResource())
                                        .ToList(),
                                    enc.EncounterSlot?.Rarity,
                                    enc.EncounterSlot?.EncounterMethod?.ToNamedApiResource()))
                                .ToList();

                            return new VersionEncounterDetail(version, maxChance, encounterDetails);
                        })
                        .ToList();

                    return new LocationAreaEncounter(locationArea, versionDetails);
                })
                .ToList();
        }

        private static List<PokemonAbility> GetAbilities(EFPokemon pokemon)
        {
            return pokemon
                .PokemonAbilities
                .Select(x => new PokemonAbility(x.IsHidden, x.Slot, x.Ability.ToNamedApiResource()))
                .ToList();
        }

        private static List<NamedAPIResource> GetForms(EFPokemon pokemon)
        {
            return pokemon
                .PokemonForms
                .Select(x => x.ToNamedApiResource())
                .ToList();
        }

        private static List<VersionGameIndex> GetGameIndices(EFPokemon pokemon)
        {
            return pokemon
                .PokemonGameIndices
                .Select(x => new VersionGameIndex(x.GameIndex, x.Version.ToNamedApiResource()))
                .ToList();
        }

        private static List<PokemonHeldItem> GetHeldItems(EFPokemon pokemon)
        {
            return pokemon
                .PokemonItems
                .GroupBy(x => x.Item, (g, elements) =>
                {
                    var pokemonHeldItemVersions = elements
                        .Select(z => new PokemonHeldItemVersion(z.Rarity, z.Version?.ToNamedApiResource()))
                        .ToList();

                    return new PokemonHeldItem(g.ToNamedApiResource(), pokemonHeldItemVersions);
                })
                .ToList();
        }

        private static string GetLocationAreaEncounters(EFPokemon pokemon)
        {
            return typeof(PokemonsController).RscUrl($"{pokemon.Id}/encounters");
        }

        private static List<PokemonMove> GetMoves(EFPokemon pokemon)
        {
            return pokemon
                .PokemonMoves
                .GroupBy(x => x.Move, (g, elements) =>
                    new PokemonMove
                    {
                        Move = g.ToNamedApiResource(),
                        VersionGroupDetails = elements
                            .Select(z => new PokemonMoveVersion
                            (
                                z.PokemonMoveMethod.ToNamedApiResource(),
                                z.VersionGroup.ToNamedApiResource(),
                                z.Level
                            ))
                            .ToList()
                    })
                .ToList();
        }

        //private PokemonSprites GetSprites(EFPokemon pokemon)
        //{
        //    return null;
        //    //return new PokemonSprites
        //    //{
        //    //    FrontDefault = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png",
        //    //    FrontShiny = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/1.png",
        //    //    FrontFemale = null,
        //    //    FrontShinyFemale = null,
        //    //    BackDefault = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/1.png",
        //    //    BackShiny = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/shiny/1.png",
        //    //    BackFemale = null,
        //    //    BackShinyFemale = null
        //    //};
        //}

        private static NamedAPIResource GetSpecies(EFPokemon pokemon)
        {
            return pokemon
                .Species
                .ToNamedApiResource();
        }

        private static List<PokemonStat> GetStats(EFPokemon pokemon)
        {
            return pokemon
                .PokemonStats
                .Select(x => new PokemonStat(x.Stat.ToNamedApiResource(), x.Effort, x.BaseStat))
                .ToList();
        }

        private static List<PokemonType> GetTypes(EFPokemon pokemon)
        {
            return pokemon
                .PokemonTypes
                .Select(x => new PokemonType(x.Slot, x.Type.ToNamedApiResource()))
                .ToList();
        }
    }
}