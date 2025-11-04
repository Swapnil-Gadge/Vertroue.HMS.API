namespace Vertroue.HMS.API.Application.Models.Hospital
{
    public class ContactDto
    {
        public int ContactId { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string ContactNo { get; set; }

        public int? EmpanelledInsCompId { get; set; }

        public int? EmpanelledTpaId { get; set; }

        public string EmpanelledInsComp { get; set; }

        public string EmpanelledTpa { get; set; }

        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
    }
}
