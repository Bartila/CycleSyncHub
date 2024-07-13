using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleSyncHub.Application.Bike
{
    public class BikeDto
    {
        public string Model { get; set; } = default!;
        public string? Description { get; set; } 
        public string? About { get; set; }
        public string? TypeOfBike { get; set; }
        public string? Weight { get; set; }
        public string? Size { get; set; }
        public string? GroupSet { get; set; }

        public string? EncodedName { get; set; }
        public bool IsEditable { get; set; }
    }
}
