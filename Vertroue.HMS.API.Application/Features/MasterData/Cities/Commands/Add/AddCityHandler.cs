using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

namespace Vertroue.HMS.API.Application.Features.MasterData.Cities.Commands.Add;

public class AddCityHandler : IRequestHandler<AddCityCommand, string>
{
    private readonly IMasterDataRepository _repository;

    public AddCityHandler(IMasterDataRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(AddCityCommand request, CancellationToken cancellationToken)
    {
        return await _repository.ManageCityAsync(request, 'I');
    }
}