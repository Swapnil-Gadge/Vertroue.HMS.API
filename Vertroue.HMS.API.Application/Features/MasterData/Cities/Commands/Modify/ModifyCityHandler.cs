using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.Cities.Commands.Modify;

public class ModifyCityHandler : IRequestHandler<ModifyCityCommand, string>
{
    private readonly IMasterDataRepository _repository;

    public ModifyCityHandler(IMasterDataRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(ModifyCityCommand request, CancellationToken cancellationToken)
    {
        return await _repository.ManageCityAsync(request, 'U');
    }
}