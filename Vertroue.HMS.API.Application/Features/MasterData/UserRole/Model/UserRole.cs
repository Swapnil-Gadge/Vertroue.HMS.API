namespace Vertroue.HMS.API.Application.Features.MasterData.UserRole.Model
{
    public class UserRoleDto
    {
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public string ActiveFlag { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
