using AutoMapper;
using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Model;

namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Queries
{
    public class GetInsuranceCompanyDetailsQueryHandler : IRequestHandler<GetInsuranceCompanyDetailsQuery, InsurerDto>
    {
        private readonly IMasterDataRepository _masterDataRepository;
        private readonly IMapper _mapper;

        public GetInsuranceCompanyDetailsQueryHandler(IMasterDataRepository masterDataRepository, IMapper mapper)
        {
            _masterDataRepository = masterDataRepository;
            _mapper = mapper;
        }

        public async Task<InsurerDto> Handle(GetInsuranceCompanyDetailsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<InsurerDto>(await _masterDataRepository.GetInsuranceCompanyAsync(request.InsuranceCompanyId));
        }
    }
}
