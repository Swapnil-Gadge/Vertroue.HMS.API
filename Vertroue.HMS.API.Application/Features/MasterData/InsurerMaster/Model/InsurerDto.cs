
namespace Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Model
{
    public class InsurerDto
    {
        public int InsuranceCompanyId { get; set; }

        public string Name { get; set; } = null!;

        public string? ContactNumber { get; set; }

        public string? FaxNumber { get; set; }

        public string WebSite { get; set; } = null!;

        public string? Code { get; set; }

        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
    }
}
