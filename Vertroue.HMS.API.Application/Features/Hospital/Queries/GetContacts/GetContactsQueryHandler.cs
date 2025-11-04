using MediatR;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Models.Hospital;
using AutoMapper;

namespace Vertroue.HMS.API.Application.Features.Hospital.Queries.GetContacts
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, GetContactsResponse>
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;

        public GetContactsQueryHandler(IHospitalRepository hospitalRepository, ILoggedInUserService loggedInUserService, IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
        }

        public async Task<GetContactsResponse> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            if (_loggedInUserService.IsUserUnauthorizedToPerformOperation(request.HospitalId))
                throw new UnauthorizedAccessException("You are not authorized to access this resource.");

            var result = await _hospitalRepository.GetContacts(request.HospitalId, request.EmpanelledInsCompId, request.EmpanelledTpaId, request.ContactId);
            var contacts = result.Select(c => new ContactDto
            {
                ContactId = c.ContactId,
                Name = c.Name,
                ContactNo = c.ContactNo,
                Email = c.Email,
                IsActive = c.IsActive,
                EmpanelledInsCompId = c.EmpanelledInsCompId,
                EmpanelledTpaId = c.EmpanelledTpaId,
                EmpanelledInsComp = c.EmpanelledInsComp?.InsuranceCompany?.Name,
                EmpanelledTpa = c.EmpanelledTpa?.Tpa?.Name,
                CreatedDate = c.CreatedDate,
                CreatedBy = c.CreatedBy,
                LastUpdatedBy = c.LastUpdatedBy,
                LastUpdatedDate = c.LastUpdatedDate
            }).ToList();

            var empanelledInsCompanies = await _hospitalRepository.GetEmpanelledInsuranceCompanies(request.HospitalId, null);
            var empanelledTpas = await _hospitalRepository.GetEmpanelledTpas(request.HospitalId, null);
            
            return new GetContactsResponse
            {
                Contacts = contacts,
                InsuranceCompanies = _mapper.Map<List<EmpanelledInsuranceCompanyDto>>(empanelledInsCompanies),
                Tpas = _mapper.Map<List<EmpanelledTpaDto>>(empanelledTpas),
            };
        }
    }
}
