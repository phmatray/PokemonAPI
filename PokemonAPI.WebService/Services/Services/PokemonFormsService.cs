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
    public class PokemonFormsService : IPokemonFormsService
    {
        private readonly VeekunContext _context;

        public PokemonFormsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.PokemonForms.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFPokemonForms, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .PokemonForms
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<PokemonForm> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<PokemonForm> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<PokemonForm> Get(Expression<Func<EFPokemonForms, bool>> predicate)
        {
            var pokemonForm = await _context
                .PokemonForms
                .AsNoTracking()
                .Include(x => x.Pokemon)
                .Include(x => x.IntroducedInVersionGroup)
                .Include(x => x.PokemonFormNames).ThenInclude(x => x.LocalLanguage)
                .FirstOrDefaultAsync(predicate);

            if (pokemonForm == null)
                return null;

            return new PokemonForm
            {
                Id           = pokemonForm.Id,
                Name         = pokemonForm.Identifier,
                Order        = pokemonForm.Order,
                FormOrder    = pokemonForm.FormOrder,
                IsDefault    = pokemonForm.IsDefault,
                IsBattleOnly = pokemonForm.IsBattleOnly,
                IsMega       = pokemonForm.IsMega,
                FormName     = pokemonForm.FormIdentifier,
                Pokemon      = GetPokemon(pokemonForm),
                Sprites      = null, //GetSprites(pokemonForm),
                VersionGroup = GetVersionGroup(pokemonForm),
                Names        = GetNames(pokemonForm),
                FormNames    = GetFormNames(pokemonForm)
            };
        }

        private static NamedAPIResource GetPokemon(EFPokemonForms pokemonForm)
        {
            return pokemonForm
                .Pokemon
                .ToNamedApiResource();
        }

        //private static PokemonFormSprites GetSprites(EFPokemonForms pokemonForm)
        //{
        //    var spriteUrlBase = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/";

        //    return new PokemonFormSprites
        //    {
        //        BackDefault = null, // $"{spriteUrlBase}back/{pokemonForm.Id}.png",
        //        BackShiny = null, // $"{spriteUrlBase}back/shiny/{pokemonForm.Id}.png",
        //        FrontDefault = null, // $"{spriteUrlBase}{pokemonForm.Id}.png",
        //        FrontShiny = null  // $"{spriteUrlBase}shiny/{pokemonForm.Id}.png"
        //    };
        //}

        private static NamedAPIResource GetVersionGroup(EFPokemonForms pokemonForm)
        {
            return pokemonForm
                .IntroducedInVersionGroup
                .ToNamedApiResource();
        }

        private static List<Name> GetNames(EFPokemonForms pokemonForm)
        {
            return pokemonForm
                .PokemonFormNames
                .Where(x => x.PokemonName != null)
                .Select(x => new Name(x.PokemonName, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }

        private static List<Name> GetFormNames(EFPokemonForms pokemonForm)
        {
            return pokemonForm
                .PokemonFormNames
                .Select(x => new Name(x.FormName, x.LocalLanguage.ToNamedApiResource()))
                .ToList();
        }
    }
}