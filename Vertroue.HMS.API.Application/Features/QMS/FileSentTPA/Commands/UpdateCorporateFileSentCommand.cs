using MediatR;
namespace Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Commands
{
    public class UpdateCorporateFileSentCommand : IRequest<string>
    {
        public int CorporateId { get; set; }
        public int CaseId { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
        public string FileSentDate { get; set; }
        public int StatusId { get; set; }
        public string StatusRemark { get; set; }
    }
}
