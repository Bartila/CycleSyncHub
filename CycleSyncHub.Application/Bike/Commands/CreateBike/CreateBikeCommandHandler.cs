using AutoMapper;
using CycleSyncHub.Application.ApplicationUser;
using CycleSyncHub.Application.Bike;
using CycleSyncHub.Domain.Interfaces;
using MediatR;

namespace CycleSyncHub.Application.Commands.CreateBike
{
    public class CreateBikeCommandHandler : IRequestHandler<CreateBikeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IBikeRepository _bikeRepository;
        private readonly IUserContext _userContext;
        public CreateBikeCommandHandler(IBikeRepository bikeRepository, IMapper mapper, IUserContext userContext)
        {
            _bikeRepository = bikeRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Owner"))
            {
                return Unit.Value;
            }
            var bike = _mapper.Map<Domain.Entities.Bike>(request);

            bike.EncodeName();

            bike.CreatedById = currentUser.Id;

            await _bikeRepository.Create(bike);

            return Unit.Value;
        }
    }
}
