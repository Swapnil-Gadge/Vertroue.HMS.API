using MediatR;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.AddInsurerRates
{
    public class AddCorporateInsurerRateCommand : IRequest<string>
    {
        public int CorporateInsurerId { get; set; }
        public int CorporateId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string RateListDocument { get; set; }
        public string RateRemarks { get; set; }
    }
}
