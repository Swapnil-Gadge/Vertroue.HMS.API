using Vertroue.HMS.API.Application.Features.Patient.Commands.CreatePatientDoc;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IPatientRepository
    {
        Task<int> CreatePatientDoc(CreatePatientDocCommand cmd);
    }
}
