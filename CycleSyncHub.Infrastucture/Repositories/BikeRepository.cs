using CycleSyncHub.Domain.Entities;
using CycleSyncHub.Domain.Interfaces;
using CycleSyncHub.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CycleSyncHub.Infrastucture.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly CycleSyncHubDbContext _dbContext;
        public BikeRepository(CycleSyncHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
        {
            return _dbContext.SaveChangesAsync();
        }

        public async Task Create(Domain.Entities.Bike bike)
        {
            _dbContext.Add(bike);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Domain.Entities.Bike>> GetAll()
        {
            return await _dbContext.Bikes.ToListAsync();
        }

		public async Task<Bike> GetByEncodedName(string encodedName)
		{
			return await _dbContext.Bikes.FirstAsync(c => c.EncodedName == encodedName);
		}

		public Task<Domain.Entities.Bike?> GetByName(string name)
        {
            return _dbContext.Bikes.FirstOrDefaultAsync(cw => cw.Model.ToLower() == name.ToLower());
        }

        public async Task Delete(string encodedName)
        {
            var bike = await _dbContext.Bikes.FirstOrDefaultAsync(c => c.EncodedName == encodedName);
            if (bike != null)
            {
                _dbContext.Bikes.Remove(bike);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
