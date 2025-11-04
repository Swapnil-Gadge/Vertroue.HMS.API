using AutoMapper;
using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Models.Hospital;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetMous
{
    public class GetMousQueryHandler : IRequestHandler<GetMousQuery, GetMousQueryResponse>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;

        public GetMousQueryHandler(IHospitalRepository hospitalRepository, ILoggedInUserService loggedInUserService, IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
        }

        public async Task<GetMousQueryResponse> Handle(GetMousQuery request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("Only Provider Admin users can access this resource.");

            var result = await _hospitalRepository.GetMous(request.HospitalId, request.EmpanelledInsCompId, request.EmpanelledTpaId, request.MouId);
            var mous = result.Select(m => new MouDto
            {
                MouId = m.Mouid,
                EmpanelledInsCompId = m.EmpanelledInsCompId,
                EmpanelledTpaId = m.EmpanelledTpaId,
                EmpanelledInsComp = m.EmpanelledInsComp?.InsuranceCompany?.Name,
                EmpanelledTpa = m.EmpanelledTpa?.Tpa?.Name,
                IsActive = m.IsActive,
                DocName = m.DocName,
                DocUri = m.DocUri,
                MouStartDate = m.MouStartDate,
                MouEndDate = m.MouEndDate,
                CreatedBy = m.CreatedBy,
                CreatedDate = m.CreatedDate,
                LastUpdatedBy = m.LastUpdatedBy,
                LastUpdatedDate = m.LastUpdatedDate
            }).ToList();

            var empanelledInsCompanies = await _hospitalRepository.GetEmpanelledInsuranceCompanies(request.HospitalId, null);
            var empanelledTpas = await _hospitalRepository.GetEmpanelledTpas(request.HospitalId, null);

            return new GetMousQueryResponse
            {
                Mous = mous,
                InsuranceCompanies = _mapper.Map<List<EmpanelledInsuranceCompanyDto>>(empanelledInsCompanies),
                Tpas = _mapper.Map<List<EmpanelledTpaDto>>(empanelledTpas),
            };
        }
    }
}
