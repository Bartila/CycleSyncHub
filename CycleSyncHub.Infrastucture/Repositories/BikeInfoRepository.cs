using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleSyncHub.Domain.Entities;
using CycleSyncHub.Domain.Interfaces;
using CycleSyncHub.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CycleSyncHub.Infrastucture.Repositories
{
    public class BikeInfoRepository : IBikeInfoRepository
    {
        private readonly CycleSyncHubDbContext _dbContext;
        public BikeInfoRepository(CycleSyncHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(BikeInfo bikeInfo)
        {
            _dbContext.Infos.Add(bikeInfo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BikeInfo>> GetAllByEncodedName(string encodedName)
        => await _dbContext.Infos
            .Where(s => s.Bike.EncodedName == encodedName)
            .ToListAsync();
    }
}
