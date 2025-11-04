namespace Vertroue.HMS.API.Application.Models.Hospital
{
    public class EmpanelledInsuranceCompanyDto
    {
        public int EmpanelledInsCompId { get; set; }
        public int? InsuranceCompanyId { get; set; }
        public string InsuranceCompanyName { get; set; } = null!;
        public DateTime? EmpanelledDate { get; set; }
        public string Portal { get; set; } = null!;
        public string? UserName { get; set; }
        public string? PassWord { get; set; }
        public int? HospitalId { get; set; }
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
