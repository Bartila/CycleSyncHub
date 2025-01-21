using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CycleSyncHub.Domain.Entities
{
    public class BikeDetails
    {
        public string? TypeOfBike { get; set; }
        public string? Weight { get; set; }
        public string? Size { get; set; }
        public string? GroupSet { get; set; }
    }

}
