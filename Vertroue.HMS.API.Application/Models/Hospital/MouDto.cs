namespace Vertroue.HMS.API.Application.Models.Hospital
{
    public class MouDto
    {
        public int MouId { get; set; }
        public int? EmpanelledInsCompId { get; set; }
        public int? EmpanelledTpaId { get; set; }
        public string EmpanelledInsComp { get; set; } = null!;
        public string EmpanelledTpa { get; set; } = null!;
        public string DocName { get; set; } = null!;
        public string DocUri { get; set; } = null!;
        public DateTime? MouStartDate { get; set; }
        public DateTime? MouEndDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? LastUpdatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
    }
}
