using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleSyncHub.Domain.Entities
{
    public class BikeInfo
    {
        public int Id { get; set; }
        public string Info { get; set; } = default!;
        public string Cost { get; set; } = default!;

        public int BikeId { get; set; } = default!;
        public Bike Bike { get; set; } = default!;
    }
}
