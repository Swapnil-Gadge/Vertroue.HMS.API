namespace Vertroue.HMS.API.Application.Features.Users.Commands.UpdatePassword
{
    public class UpdatePasswordRequestDto
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
