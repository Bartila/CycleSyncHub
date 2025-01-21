using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleSyncHub.Domain.Entities;

namespace CycleSyncHub.Domain.Interfaces
{
    public interface IBikeInfoRepository
    {
        Task Create(BikeInfo bikeInfo);
        Task<IEnumerable<BikeInfo>> GetAllByEncodedName(string encodedName);
    }
}
