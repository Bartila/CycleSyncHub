using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CycleSyncHub.Application.BikeInfo.Queries.GetBikeInfos
{
    public class GetBikeInfosQuery : IRequest<IEnumerable<BikeInfoDto>>
    {
        public string EncodedName { get; set; } = default!;
    }
}
