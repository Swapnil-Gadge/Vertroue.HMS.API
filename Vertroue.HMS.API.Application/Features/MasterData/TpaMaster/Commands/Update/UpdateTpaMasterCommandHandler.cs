using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

public class UpdateTpaMasterCommandHandler : IRequestHandler<UpdateTpaMasterCommand, string>
{
    private readonly IMasterDataRepository _repository;
    public UpdateTpaMasterCommandHandler(IMasterDataRepository repository) => _repository = repository;

    public async Task<string> Handle(UpdateTpaMasterCommand request, CancellationToken cancellationToken)
    {
        return await _repository.ManageTpaMasterAsync(request, 'U');
    }
}
