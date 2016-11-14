using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NuGet.Protocol.Core.v3;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Controllers
{
    public class PokemonLite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public bool IsBaby { get; set; }
        public List<PokemonAbility> Abilities { get; set; }
        public List<PokemonStat> Stats { get; set; }
        public List<NamedAPIResource> EggGroups { get; set; }
        public List<PokemonType> Types { get; set; }
    }

    [Route("api/v1/temp")]
    public class TempController : ApiController
    {
        private readonly VeekunContext _context;

        public TempController(VeekunContext context)
        {
            _context = context;
        }

        // GET api/v1/temp
        [HttpGet]
        public async Task<string> GetAllPokemons()
        {
            var pokemons = await _context
                .Pokemon
                .AsNoTracking()
                .Include(x => x.Species)
                    .ThenInclude(x => x.PokemonEggGroups)
                    .ThenInclude(x => x.EggGroup)
                .Include(x => x.PokemonTypes)
                    .ThenInclude(x => x.Type)
                    .ThenInclude(x => x.TypeNames)
                    .ThenInclude(x => x.LocalLanguage)
                .Include(x => x.PokemonStats)
                    .ThenInclude(x => x.Stat)
                //.Include(x => x.Species).ThenInclude(x => x.PokemonEggGroups)
                //.Include(x => x.PokemonStats).ThenInclude(x => x.Stat)
                .Select(x => new PokemonLite
                {
                    Id          = x.Id,
                    Name        = x.Identifier,
                    Gender      = x.Species.GenderRate,
                    IsBaby      = x.Species.IsBaby,
                    Abilities   = GetAbilities(x),
                    Stats       = GetStats(x),
                    EggGroups   = GetEggGroups(x.Species),
                    Types       = GetTypes(x),
                })
                .ToListAsync();

            return pokemons.ToJson();
        }

        private static List<PokemonAbility> GetAbilities(EFPokemon pokemon)
        {
            return pokemon
                .PokemonAbilities
                .Select(x => new PokemonAbility(x.IsHidden, x.Slot, x.Ability.ToNamedApiResource()))
                .ToList();
        }

        private static List<PokemonType> GetTypes(EFPokemon pokemon)
        {
            return pokemon
                .PokemonTypes
                .Select(x => new PokemonType(x.Slot, x.Type.ToNamedApiResource()))
                .ToList();
        }

        private static List<PokemonStat> GetStats(EFPokemon pokemon)
        {
            return pokemon
                .PokemonStats
                .Select(x => new PokemonStat(x.Stat.ToNamedApiResource(), x.Effort, x.BaseStat))
                .ToList();
        }

        private static List<NamedAPIResource> GetEggGroups(EFPokemonSpecies species)
        {
            return null;
            //return species
            //    .PokemonEggGroups
            //    .Select(x => x.ToNamedApiResource())
            //    .ToList();
        }
    }
}