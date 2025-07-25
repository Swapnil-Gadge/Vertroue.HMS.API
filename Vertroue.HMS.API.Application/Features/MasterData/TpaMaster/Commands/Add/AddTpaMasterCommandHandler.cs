using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

public class AddTpaMasterCommandHandler : IRequestHandler<AddTpaMasterCommand, string>
{
    private readonly IMasterDataRepository _repository;
    public AddTpaMasterCommandHandler(IMasterDataRepository repository) => _repository = repository;

    public async Task<string> Handle(AddTpaMasterCommand request, CancellationToken cancellationToken)
    {
        return await _repository.ManageTpaMasterAsync(request, 'I');
    }
}
