/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleSyncHub.Infrastucture.Persistence;

namespace CycleSyncHub.Infrastucture
{
    public class BikeSeeder
    {
        private readonly CycleSyncHubDbContext _dbContext;
        public BikeSeeder(CycleSyncHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Bikes.Any())
                {
                    var scott = new Domain.Entities.Bike()
                    {
                        Model = "Scott",
                        Description = "premium",
                        BikesDetails = new()
                        {
                            TypeOfBike = "road",
                            Weight = "8 kg",
                            Size = "L",
                            GroupSet = "shimano 105"
                        }
                    };

                    scott.EncodeName();

                    _dbContext.Bikes.Add(scott);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
*/