using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Commands;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Queries;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IQMSDataRepository    {
        Task<GetCorporatePendingFileSentResponse> FetchCorporatePendingFileSentAsync(int corporateId, int userId, string userType, string userRole);
        Task<string> UpdateCorporatePendingFileSentAsync(UpdateCorporateFileSentCommand request);
    }
}
