using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;

public class UpdateTpaMasterCommandHandler : IRequestHandler<UpdateTpaMasterCommand, bool>
{
    private readonly IMasterDataRepository _repository;
    public UpdateTpaMasterCommandHandler(IMasterDataRepository repository) => _repository = repository;

    public async Task<bool> Handle(UpdateTpaMasterCommand request, CancellationToken cancellationToken)
    {
        return await _repository.AddUpdateTPA(request);
    }
}
