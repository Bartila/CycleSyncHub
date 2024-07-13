using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleSyncHub.Domain.Entities;

namespace CycleSyncHub.Domain.Interfaces
{
    public interface IBikeRepository
    {
        Task Create(Domain.Entities.Bike bike);
        Task<Domain.Entities.Bike?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.Bike>> GetAll();
        Task<Domain.Entities.Bike> GetByEncodedName(string encodedName);
        Task Commit();
        Task Delete(string encodedName);
    }
}
