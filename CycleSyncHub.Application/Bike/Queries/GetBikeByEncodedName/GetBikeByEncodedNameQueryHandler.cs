using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CycleSyncHub.Domain.Interfaces;
using MediatR;

namespace CycleSyncHub.Application.Bike.Queries.GetBikeByEncodedName
{
	public class GetBikeByEncodedNameQueryHandler : IRequestHandler<GetBikeByEncodedNameQuery, BikeDto>
	{
		private readonly IBikeRepository _bikeRepository;
		private readonly IMapper _mapper;
		public GetBikeByEncodedNameQueryHandler(IBikeRepository bikeRepository, IMapper mapper)
		{
			_bikeRepository = bikeRepository;
			_mapper = mapper;
		}
		public async Task<BikeDto> Handle(GetBikeByEncodedNameQuery request, CancellationToken cancellationToken)
		{
			var bike = await _bikeRepository.GetByEncodedName(request.EncodedName);

			var dto = _mapper.Map<BikeDto>(bike);

			return dto;
		}
	}
}
