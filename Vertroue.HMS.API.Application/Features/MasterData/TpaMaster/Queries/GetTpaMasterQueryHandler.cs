using AutoMapper;
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.TpaMaster.Model;

public class GetTpaMasterQueryHandler : IRequestHandler<GetTpaMasterQuery, List<TpaMasterDto>>
{
    private readonly IMasterDataRepository _repository;
    private readonly IMapper _mapper;

    public GetTpaMasterQueryHandler(IMasterDataRepository repository, IMapper mapper)
    { 
        _repository = repository; 
        _mapper = mapper;
    }

    public async Task<List<TpaMasterDto>> Handle(GetTpaMasterQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<TpaMasterDto>>(await _repository.FetchTpaMasterAsync());
    }
}
