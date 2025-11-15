using Vertroue.HMS.API.Application.Features.Patient.Commands.CreateClaimFlowDoc;
using Vertroue.HMS.API.Application.Features.Patient.Commands.CreatePatientDoc;
using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IPatientRepository
    {
        Task<int> CreatePatientDoc(CreatePatientDocCommand cmd);
        Task<string> DeletePatientDoc(int patientDocId);
        Task<List<PatientDoc?>> GetPatientDocsByPatientIdAsync(int patientId);
        Task<List<Patient>> GetPatientsByHospitalIdAsync(int hospitalId);
        Task<int> CreateClaimFlowDoc(CreateClaimFlowDocCommand cmd);
        Task<string> DeleteClaimFlowDoc(int claimFlowDocId);
        Task<Patient> AddPatientAsync(Patient patient);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task<Patient?> GetPatientByIdAsync(int patientId, bool onlyPatient = false);
        Task<ClaimFlow> AddClaimFlowAsync(ClaimFlow claimFlow);
        Task<ClaimFlow> UpdateClaimFlowAsync(ClaimFlow claimFlow);
        Task<List<ClaimFlow?>> GetClaimFlowByPatientIdAsync(int patientId);
        Task<bool> UpdateClaimFlowDocs(List<int> ids, int claimflowId);
        Task<List<ClaimFlowDoc?>> GetClaimFlowDocsByClaimFlowIdAsync(int claimFlowId);
        Task<bool> DeleteClaimFlow(int claimFlowId);
        Task<ClaimFlow?> GetClaimFlowByIdAsync(int claimFlowId);
        Task<bool> UpdatePatientDocsFlag(List<int> ids, int patientId);
        Task<bool> UpdateClaimStatus(int patientId, string status);
    }
}
