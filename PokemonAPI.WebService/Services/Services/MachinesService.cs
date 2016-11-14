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
    public class MachinesService : IMachinesService
    {
        private readonly VeekunContext _context;

        public MachinesService(VeekunContext context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Machines.CountAsync();
        }

        public async Task<List<APIResource>> GetAll(int limit, int offset)
        {
            return await GetAll(x => true, limit, offset);
        }

        public async Task<List<APIResource>> GetAll(Expression<Func<EFMachines, bool>> predicate, int limit, int offset)
        {
            if (limit <= 0 || offset < 0)
                return null;

            var apiResults = await _context
                .Machines
                .AsNoTracking()
                .Where(predicate)
                .OrderBy(x => x.MachineNumber)
                .Skip(offset)
                .Take(limit)
                .Select(x => x.ToApiResource())
                .ToListAsync();

            return apiResults;
        }

        public async Task<Machine> Get(int machineNumber, int versionGroupId)
        {
            return await Get(x => x.MachineNumber == machineNumber && x.VersionGroupId == versionGroupId);
        }

        public async Task<Machine> Get(Expression<Func<EFMachines, bool>> predicate)
        {
            var machine = await _context.Machines
                .AsNoTracking()
                .Include(x => x.Item)
                .Include(x => x.Move)
                .Include(x => x.VersionGroup)
                .FirstOrDefaultAsync(predicate);

            if (machine == null)
                return null;

            return new Machine
            {
                Id           = $"{machine.MachineNumber}/{machine.VersionGroupId}",
                Item         = machine.Item?.ToNamedApiResource(),
                Move         = machine.Move?.ToNamedApiResource(),
                VersionGroup = machine.VersionGroup?.ToNamedApiResource()
            };
        }
    }
}