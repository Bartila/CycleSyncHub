using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleSyncHub.Application.ApplicationUser;
using CycleSyncHub.Domain.Interfaces;
using MediatR;

namespace CycleSyncHub.Application.BikeInfo.Commands
{
    public class CreateBikeInfoCommandHandler : IRequestHandler<CreateBikeInfoCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IBikeRepository _bikeRepository;
        private readonly IBikeInfoRepository _bikeInfoRepository;
        public CreateBikeInfoCommandHandler(IUserContext userContext, IBikeRepository bikeRepository, IBikeInfoRepository bikeInfoRepository)
        {
            _userContext = userContext;
            _bikeRepository = bikeRepository;
            _bikeInfoRepository = bikeInfoRepository;
        }
        public async Task<Unit> Handle(CreateBikeInfoCommand request, CancellationToken cancellationToken)
        {
            var bike = await _bikeRepository.GetByEncodedName(request.BikeEncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (bike.CreatedById == user.Id || user.IsInRole("Owner"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            var bikeInfo = new Domain.Entities.BikeInfo()
            {
                Cost = request.Cost,
                Info = request.Info,
                BikeId = bike.Id,
            };

            await _bikeInfoRepository.Create(bikeInfo);

            return Unit.Value;
        }
    }
}
