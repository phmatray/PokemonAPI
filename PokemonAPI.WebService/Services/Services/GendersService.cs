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
    public class GendersService : IGendersService
    {
        private readonly VeekunContext _context;

        public GendersService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Genders.CountAsync();
        }

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<NamedAPIResource>> GetAll(Expression<Func<EFGenders, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Genders
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToNamedApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Gender> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<Gender> Get(string name)
        {
            return await Get(x => x.Identifier == name);
        }

        public async Task<Gender> Get(Expression<Func<EFGenders, bool>> predicate)
        {
            var gender = await _context
                .Genders
                .AsNoTracking()
                .Include(x => x.PokemonEvolution).ThenInclude(x => x.EvolvedSpecies)
                .FirstOrDefaultAsync(predicate);

            if (gender == null)
                return null;

            return new Gender
            {
                Id                    = gender.Id,
                Name                  = gender.Identifier,
                PokemonSpeciesDetails = await GetPokemonSpeciesDetails(gender),
                RequiredForEvolution  = GetRequiredForEvolution(gender)
            };
        }

        private async Task<List<PokemonSpeciesGender>> GetPokemonSpeciesDetails(EFGenders gender)
        {
            var pokemonSpecies = new List<EFPokemonSpecies>();
            switch (gender.Identifier)
            {
                case "female":
                    pokemonSpecies = await _context
                        .PokemonSpecies
                        .Where(x => x.GenderRate >= 1 && x.GenderRate <= 8)
                        .ToListAsync();
                    break;
                case "male":
                    pokemonSpecies = await _context
                        .PokemonSpecies
                        .Where(x => x.GenderRate >= 0 && x.GenderRate <= 7)
                        .ToListAsync();
                    break;
                case "genderless":
                    pokemonSpecies = await _context
                        .PokemonSpecies
                        .Where(x => x.GenderRate == -1)
                        .ToListAsync();
                    break;
            }

            return pokemonSpecies
                .Select(x => new PokemonSpeciesGender
                {
                    Rate = x.GenderRate,
                    PokemonSpecies = x.ToNamedApiResource()
                })
                .ToList();
        }

        private static List<NamedAPIResource> GetRequiredForEvolution(EFGenders gender)
        {
            return gender
                .PokemonEvolution
                .Select(x => x.EvolvedSpecies.ToNamedApiResource())
                .ToList();
        }
    }
}