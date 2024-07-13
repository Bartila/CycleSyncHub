using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CycleSyncHub.Application.Bike.Queries.GetAllBikes
{
    public class GetAllBikesQuery : IRequest<IEnumerable<BikeDto>>
    {

    }
}
