using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CycleSyncHub.Domain.Interfaces;
using MediatR;

namespace CycleSyncHub.Application.Bike.Queries.GetAllBikes
{
    public class GetAllBikesQueryHandler : IRequestHandler<GetAllBikesQuery, IEnumerable<BikeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBikeRepository _bikeRepository;
        public GetAllBikesQueryHandler(IBikeRepository bikeRepository, IMapper mapper)
        {
            _bikeRepository = bikeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BikeDto>> Handle(GetAllBikesQuery request, CancellationToken cancellation)
        {
            var bikes = await _bikeRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<BikeDto>>(bikes);

            return dtos;
        }

    }
}
