using CycleSyncHub.Domain.Interfaces;
using MediatR;

public class DeleteBikeCommandHandler : IRequestHandler<DeleteBikeCommand>
{
    private readonly IBikeRepository _bikeRepository;

    public DeleteBikeCommandHandler(IBikeRepository bikeRepository)
    {
        _bikeRepository = bikeRepository;
    }

    public async Task<Unit> Handle(DeleteBikeCommand request, CancellationToken cancellationToken)
    {
        await _bikeRepository.Delete(request.EncodedName);
        return Unit.Value;
    }
}
