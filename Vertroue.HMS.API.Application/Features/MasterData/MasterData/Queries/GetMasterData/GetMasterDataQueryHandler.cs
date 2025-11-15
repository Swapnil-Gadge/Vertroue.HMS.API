using AutoMapper;
using MediatR;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Models.Hospital;
using Vertroue.HMS.API.Application.Models.Master;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Application.Features.MasterData.MasterData.Queries.GetMasterData
{
    public class GetMasterDataQueryHandler : IRequestHandler<GetMasterDataQuery, GetMasterDataQueryResponse>
    {
        private readonly IMasterDataRepository _masterDataRepository;
        private readonly IMapper _mapper;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetMasterDataQueryHandler(IMasterDataRepository masterDataRepository, IMapper mapper, ILoggedInUserService loggedInUserService)
        {
            _masterDataRepository = masterDataRepository;
            _mapper = mapper;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<GetMasterDataQueryResponse> Handle(GetMasterDataQuery request, CancellationToken cancellationToken)
        {
            var userRole = _loggedInUserService.UserRole;
            var result = await _masterDataRepository.GetMasterData(request.HospitalId);

            var empanelledTPAs = new List<EmpanelledTpaDto>();
            var empanelledICs = new List<EmpanelledInsuranceCompanyDto>();

            result.Item13.ForEach((tpa) => empanelledTPAs.Add(new EmpanelledTpaDto
            {
                EmpanelledTpaId = tpa.EmpanelledTpaId,
                TpaId = tpa.Tpaid,
                TpaName = tpa?.Tpa?.Name ?? string.Empty,
                ContactNumber = tpa?.Tpa?.ContactNumber,
                FaxNumber = tpa?.Tpa?.FaxNumber,        
                IsActive = tpa.IsActive,
                HospitalId = tpa.HospitalId,
            }));

            result.Item14.ForEach((ic) => empanelledICs.Add(new EmpanelledInsuranceCompanyDto
            {
                EmpanelledInsCompId = ic.EmpanelledInsCompId,
                InsuranceCompanyId = ic.InsuranceCompanyId,
                InsuranceCompanyName = ic?.InsuranceCompany?.Name ?? string.Empty,
                ContactNumber = ic?.InsuranceCompany?.ContactNumber,
                FaxNumber = ic?.InsuranceCompany?.FaxNumber,
                IsActive = ic.IsActive,
                HospitalId = ic.HospitalId,
            }));

            return new GetMasterDataQueryResponse
            {
                Cities = _mapper.Map<List<CityDto>>(result.Item1),
                States = _mapper.Map<List<StateDto>>(result.Item2),
                AdmissionTypes = _mapper.Map<List<AdmissionTypeDto>>(result.Item3),
                ClaimStatuses = _mapper.Map<List<ClaimStatusDto>>(result.Item4),
                DischargeTypes = _mapper.Map<List<DischargeTypeDto>>(result.Item5),
                LineOfTreatments = _mapper.Map<List<LineOfTreatmentDto>>(result.Item6),
                MedicalHistoryMasters = _mapper.Map<List<MedicalHistoryMasterDto>>(result.Item7),
                RoomTypes = _mapper.Map<List<RoomTypeDto>>(result.Item8),
                Tpas = _mapper.Map<List<TpaDto>>(result.Item9),
                InsuranceCompanies = _mapper.Map<List<InsuranceCompanyDto>>(result.Item10),
                UserRoles = _mapper.Map<List<UserRoleDto>>(result.Item11),
                Hospitals = userRole == Constant.UserRoles.ProviderAdmin || userRole == Constant.UserRoles.ProviderExecutive
                    ? _mapper.Map<List<HospitalDto>>(result.Item12)
                    : new List<HospitalDto>(),
                EmpanelledInsuranceCompanies = empanelledICs,
                EmpanelledTpas = empanelledTPAs,
                Doctors = _mapper.Map<List<DoctorDto>>(result.Item15),
            };
        }
    }
}
