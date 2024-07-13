using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleSyncHub.Domain.Entities;
using MediatR;

namespace CycleSyncHub.Application.BikeInfo.Commands
{
    public class CreateBikeInfoCommand : BikeInfoDto, IRequest
    {
        public string BikeEncodedName { get; set; } = default!;
    }
}
