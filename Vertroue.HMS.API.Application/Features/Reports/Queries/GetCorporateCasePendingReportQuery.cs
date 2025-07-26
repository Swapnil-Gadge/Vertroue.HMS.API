using MediatR;
using Vertroue.HMS.API.Application.Features.Reports.Model;

namespace Vertroue.HMS.API.Application.Features.Reports.Queries
{
    public class GetCorporateCasePendingReportQuery : IRequest<List<CorporateCasePendingReportDto>>
    {
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
    }
}
