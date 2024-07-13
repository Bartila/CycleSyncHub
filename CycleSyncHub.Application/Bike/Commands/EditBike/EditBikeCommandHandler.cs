using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleSyncHub.Application.ApplicationUser;
using CycleSyncHub.Domain.Interfaces;
using MediatR;

namespace CycleSyncHub.Application.Bike.Commands.EditBike
{
    public class EditBikeCommandHandler : IRequestHandler<EditBikeCommand>
    {
        private readonly IBikeRepository _repository;
        private readonly IUserContext _userContext;
        public EditBikeCommandHandler(IBikeRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditBikeCommand request, CancellationToken cancellationToken)
        {
            var bike = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (bike.CreatedById == user.Id || user.IsInRole("userPlus"));

            if (isEditable)
            {
                return Unit.Value;
            }

            bike.Description = request.Description;
 

            bike.BikesDetails.TypeOfBike = request.TypeOfBike;
            bike.BikesDetails.Weight = request.Weight;
            bike.BikesDetails.Size = request.Size;
            bike.BikesDetails.GroupSet = request.GroupSet;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
