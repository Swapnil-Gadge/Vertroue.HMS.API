using System.Data;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Commands;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Queries;
using Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Commands;
using Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Queries;
using Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Add;
using Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Enhancement;
using Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Update;
using Vertroue.HMS.API.Application.Features.QMS.QMSControl.Queries;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface IQMSDataRepository
    {
        Task<GetCorporatePendingFileSentResponse> FetchCorporatePendingFileSentAsync(int corporateId, int userId, string userType, string userRole);
        Task<string> UpdateCorporatePendingFileSentAsync(UpdateCorporateFileSentCommand request);
        Task<FetchPaymentReceivedResponse> FetchCorporatePendingPaymentReceivedAsync(GetPaymentReceivedQuery request);
        Task<string> UpdateCorporatePendingPaymentReceivedAsync(UpdateCorporatePendingPaymentReceivedCommand command);
        Task<FetchAllQMSControlsListResponse> FetchAllQMSControlsListAsync(int userId, string userType, string userRole, int corporateId);
        Task<string> CreateQMSCaseAsync(CreateQMSCaseCommand request);
        Task<string> UpdateQMSCaseDetailsAsync(UpdateQMSCaseCommand request);
        Task<string> UpdateCaseEnhancementAsync(UpdateCaseEnhancementCommand command);
    }
}
