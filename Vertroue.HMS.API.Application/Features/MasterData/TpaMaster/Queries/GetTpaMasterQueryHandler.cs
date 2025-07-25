using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.TpaMaster.Model;

public class GetTpaMasterQueryHandler : IRequestHandler<GetTpaMasterQuery, List<TpaMasterDto>>
{
    private readonly IMasterDataRepository _repository;
    public GetTpaMasterQueryHandler(IMasterDataRepository repository) => _repository = repository;

    public async Task<List<TpaMasterDto>> Handle(GetTpaMasterQuery request, CancellationToken cancellationToken)
    {
        return await _repository.FetchTpaMasterAsync();
    }
}
