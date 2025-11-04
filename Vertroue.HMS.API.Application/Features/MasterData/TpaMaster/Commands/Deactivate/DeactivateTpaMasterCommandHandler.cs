using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

public class DeactivateTpaMasterCommandHandler : IRequestHandler<DeactivateTpaMasterCommand, bool>
{
    private readonly IMasterDataRepository _repository;
    public DeactivateTpaMasterCommandHandler(IMasterDataRepository repository) => _repository = repository;

    public async Task<bool> Handle(DeactivateTpaMasterCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DisableTPA(request.TPAId);
    }
}
