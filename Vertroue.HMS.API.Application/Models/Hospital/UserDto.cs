namespace Vertroue.HMS.API.Application.Models.Hospital
{
    public class UserDto
    {
        public int UserId { get; set; }

        public int? HospitalId { get; set; }

        public string Name { get; set; } = null!;

        public int UserRoleId { get; set; }

        public string UserRole { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string UserLoginId { get; set; } = null!;

        public string ContactNumber { get; set; }

        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
    }
}
