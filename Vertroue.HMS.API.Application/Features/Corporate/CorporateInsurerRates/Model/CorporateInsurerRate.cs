using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurerRates.Model
{
    public class CorporateInsurerRateDto
    {
        public int CorporateInsurerRatesId { get; set; }
        public int CorporateInsurerId { get; set; }
        public string? RateListDocument { get; set; }
        public string? RateRemarks { get; set; }
        public string? ActiveFlag { get; set; }
        public DateTime? RateActiveFromDate { get; set; }
        public DateTime? RateActiveToDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }        
        public string ModifiedBy { get; set; }
    }
}
