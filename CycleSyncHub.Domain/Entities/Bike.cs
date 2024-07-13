using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CycleSyncHub.Domain.Entities
{
    public class Bike
    {
        public int Id { get; set; }
        public string Model { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public BikeDetails BikesDetails { get; set; } = default!;

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }


        public string EncodedName { get; private set; } = default!; 

        public List<BikeInfo> Infos { get; set; } = new();

        public void EncodeName() => EncodedName = Model.ToLower().Replace(" ", "-");
    }
}
