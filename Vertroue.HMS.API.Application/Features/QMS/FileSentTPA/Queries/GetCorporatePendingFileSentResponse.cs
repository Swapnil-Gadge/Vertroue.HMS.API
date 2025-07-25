using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Model;

namespace Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Queries
{
    public class GetCorporatePendingFileSentResponse
    {
        public List<QMSMainRecordDto> MainRecords { get; set; }
        public List<QMSStatusDto> StatusList { get; set; }
        public List<QMSCaseDetailsDto> CaseDetails { get; set; }
        public List<QMSStatusTrackerDto> StatusTracker { get; set; }
        public List<QMSCaseTypeDto> CaseTypes { get; set; }
    }
}
