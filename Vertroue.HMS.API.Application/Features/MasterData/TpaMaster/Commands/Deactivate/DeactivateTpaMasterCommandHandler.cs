using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

public class DeactivateTpaMasterCommandHandler : IRequestHandler<DeactivateTpaMasterCommand, string>
{
    private readonly IMasterDataRepository _repository;
    public DeactivateTpaMasterCommandHandler(IMasterDataRepository repository) => _repository = repository;

    public async Task<string> Handle(DeactivateTpaMasterCommand request, CancellationToken cancellationToken)
    {
        return await _repository.ManageTpaMasterAsync(request, 'D');
    }
}
