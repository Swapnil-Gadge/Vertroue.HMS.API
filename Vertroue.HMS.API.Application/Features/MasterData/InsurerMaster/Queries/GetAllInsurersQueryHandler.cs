using MediatR;
using Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Model;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using AutoMapper;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Queries
{
    public class GetAllInsurersQueryHandler : IRequestHandler<GetAllInsurersQuery, List<InsurerDto>>
    {
        private readonly IMasterDataRepository _repository;
        private readonly IMapper _mapper;

        public GetAllInsurersQueryHandler(IMasterDataRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<InsurerDto>> Handle(GetAllInsurersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.FetchInsurersAsync();
            return _mapper.Map<List<InsurerDto>>(result);
        }
    }
}
