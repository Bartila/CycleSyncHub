using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CycleSyncHub.Domain.Interfaces;
using MediatR;

namespace CycleSyncHub.Application.BikeInfo.Queries.GetBikeInfos
{
    public class GetBikeInfosQueryHandler : IRequestHandler<GetBikeInfosQuery, IEnumerable<BikeInfoDto>>
    {
        private readonly IBikeInfoRepository _bikeInfoRepository;
        private readonly IMapper _mapper;
        public GetBikeInfosQueryHandler(IBikeInfoRepository bikeInfoRepository, IMapper mapper)
        {
            _bikeInfoRepository = bikeInfoRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BikeInfoDto>> Handle(GetBikeInfosQuery request, CancellationToken cancellationToken)
        {
            var result = await _bikeInfoRepository.GetAllByEncodedName(request.EncodedName);

            var dtos = _mapper.Map<IEnumerable<BikeInfoDto>>(result);

            return dtos;
        }
    }
}
