using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateRenewal;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateRenewal;
using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IHospitalRepository : IAsyncRepository<Hospital>
    {
        Task<bool> AddUpdateHospital(object hospital);
        Task<Hospital?> GetHospitalDetailsByIdAsync(int id);
        Task<bool> CreateNewRenewal(CreateRenewalCommand command);
        Task<bool> UpdateRenewal(UpdateRenewalCommand command);
        Task<List<RenewalDoc>> GetRenewalDocs(int renewalId);
        Task<bool> DisableRenewal(int renewalId);
        Task<List<Renewal>> GetRenewalsForHospital(int hospitalId, int? renewalId);
        Task<bool> DisableDoctor(int doctorId);
        Task<bool> AddUpdateDoctor(object doctor);
        Task<List<DoctorsMaster>> GetDoctors(int hospitalId, int? doctorId);
        Task<List<EmpanelledTpa>> GetEmpanelledTpas(int hospitalId, int? empanelledTpaId);
        Task<bool> AddUpdateEmpanelledTpa(object command);
        Task<bool> DisableEmpanelledTpa(int empanelledTpaId);
        Task<bool> AddUpdateEmpanelledInsuranceCompany(object command);
        Task<bool> DisableEmpanelledInsuranceCompany(int empanelledInsuranceCompanyId);
        Task<List<EmpanelledInsuranceCompany>> GetEmpanelledInsuranceCompanies(int hospitalId, int? empanelledInsuranceCompanyId);
        Task<bool> AddUpdateContact(object command);
        Task<bool> DisableContact(int contactId);
        Task<List<Contact>> GetContacts(int hospitalId, int? empanelledInsCompId, int? empanelledTpaId, int? contactId);
        Task<bool> AddUpdateMou(object command);
        Task<bool> DisableMou(int mouId);
        Task<List<Mou>> GetMous(int hospitalId, int? empanelledInsCompId, int? empanelledTpaId, int? mouId);
        Task<bool> DisableHospitalUser(int userId);
        Task<List<User>> GetHospitalUsers(int? hospitalId, int? userId);
        Task<bool> AddUpdateHospitalUser(object command);
    }
}
