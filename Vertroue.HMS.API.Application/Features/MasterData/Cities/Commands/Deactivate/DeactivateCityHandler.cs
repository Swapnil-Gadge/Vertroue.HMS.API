using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.Cities.Commands.Deactivate;

public class DeactivateCityHandler : IRequestHandler<DeactivateCityCommand, string>
{
    private readonly IMasterDataRepository _repository;

    public DeactivateCityHandler(IMasterDataRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(DeactivateCityCommand request, CancellationToken cancellationToken)
    {
        return await _repository.ManageCityAsync(request, 'D');
    }
}