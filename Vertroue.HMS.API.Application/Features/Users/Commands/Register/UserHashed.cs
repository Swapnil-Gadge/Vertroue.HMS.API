namespace Vertroue.HMS.API.Application.Features.Users.Commands.Register
{
    public class UserHashed
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
