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
    public class EvolutionChainsService : IEvolutionChainsService
    {
        private readonly VeekunContext _context;

        public EvolutionChainsService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.EvolutionChains.CountAsync();
        }

        public async Task<List<APIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<APIResource>> GetAll(Expression<Func<EFEvolutionChains, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .EvolutionChains
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<EvolutionChain> Get(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<EvolutionChain> Get(Expression<Func<EFEvolutionChains, bool>> predicate)
        {
            var evolutionChain = await _context.EvolutionChains
                .AsNoTracking()
                .Include(x => x.BabyTriggerItem)
                .Include(x => x.PokemonSpecies)
                .FirstOrDefaultAsync(predicate);

            if (evolutionChain == null)
                return null;

            return new EvolutionChain
            {
                Id              = evolutionChain.Id,
                BabyTriggerItem = GetBabyTriggerItem(evolutionChain),
                Chain           = GetChain(evolutionChain)
            };
        }

        private static NamedAPIResource GetBabyTriggerItem(EFEvolutionChains evolutionChain)
        {
            return evolutionChain
                .BabyTriggerItem?
                .ToNamedApiResource();
        }

        private ChainLink GetChain(EFEvolutionChains evolutionChain)
        {
            var firstStadeSpecies = evolutionChain
                .PokemonSpecies
                .Single(x => x.EvolvesFromSpeciesId == null);

            return new ChainLink
            {
                IsBaby           = firstStadeSpecies.IsBaby,
                Species          = firstStadeSpecies.ToNamedApiResource(),
                EvolutionDetails = new List<EvolutionDetail>(), // We MUST return an empty list for the first node
                EvolvesTo        = GetEvolvesToChainLinks(firstStadeSpecies)
            };
        }

        private List<ChainLink> GetEvolvesToChainLinks(EFPokemonSpecies species)
        {
            var evolutionsFromSpecies = _context
                .PokemonSpecies
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.TriggerItem)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.EvolutionTrigger)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.HeldItem)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.KnownMove)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.KnownMoveType)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.Location)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.PartySpecies)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.PartyType)
                .Include(x => x.InverseEvolvesFromSpecies).ThenInclude(x => x.PokemonEvolutionEvolvedSpecies).ThenInclude(x => x.TradeSpecies)
                .Single(x => x.Id == species.Id)
                .InverseEvolvesFromSpecies
                .ToList();

            return evolutionsFromSpecies
                .Select(evolution => new ChainLink
                {
                    IsBaby = evolution.IsBaby,
                    Species = evolution.ToNamedApiResource(),
                    EvolutionDetails = evolution
                        .PokemonEvolutionEvolvedSpecies
                        .Select(x => new EvolutionDetail
                        {
                            Item                  = x.TriggerItem?.ToNamedApiResource(),
                            Trigger               = x.EvolutionTrigger?.ToNamedApiResource(),
                            Gender                = x.GenderId,
                            HeldItem              = x.HeldItem?.ToNamedApiResource(),
                            KnownMove             = x.KnownMove?.ToNamedApiResource(),
                            KnownMoveType         = x.KnownMoveType?.ToNamedApiResource(),
                            Location              = x.Location?.ToNamedApiResource(),
                            MinLevel              = x.MinimumLevel,
                            MinHappiness          = x.MinimumHappiness,
                            MinBeauty             = x.MinimumBeauty,
                            MinAffection          = x.MinimumAffection,
                            NeedsOverworldRain    = x.NeedsOverworldRain,
                            PartySpecies          = x.PartySpecies?.ToNamedApiResource(),
                            PartyType             = x.PartyType?.ToNamedApiResource(),
                            RelativePhysicalStats = x.RelativePhysicalStats,
                            TimeOfDay             = x.TimeOfDay,
                            TradeSpecies          = x.TradeSpecies?.ToNamedApiResource(),
                            TurnUpsideDown        = x.TurnUpsideDown
                        }).ToList(),
                    EvolvesTo = GetEvolvesToChainLinks(evolution)
                })
                .ToList();
        }
    }
}