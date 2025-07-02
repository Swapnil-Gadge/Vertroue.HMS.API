using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Users.Commands.Register;

namespace Vertroue.HMS.API.Application.Features.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserMasterRepository _userMasterRepository;

        public LoginCommandHandler(IConfiguration configuration, IUserMasterRepository userMasterRepository)
        {
            _configuration = configuration;
            _userMasterRepository = userMasterRepository;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var userMaster = await _userMasterRepository.GetUserDetails(request.UserName);

            if (userMaster == null)
                throw new UnauthorizedAccessException();

            var user = new UserHashed
            {
                UserName = request.UserName,
                PasswordHash = userMaster.UserPassword
            };
            var passwordHasher = new PasswordHasher<UserHashed>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

            if (result != PasswordVerificationResult.Success)
                throw new UnauthorizedAccessException();

            // Create JWT TOKEN
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("SecretKey").Value); // store in appsettings!
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, userMaster.UserRole?.User_role_Name ?? "User"),
                    new Claim("CorporateName", userMaster.Corporate?.Corporate_Name ?? "User"),
                    new Claim("UserTypeName", userMaster.UserType?.User_Type_Name ?? "User"),
                    new Claim("UserTypeId", userMaster.UserType?.User_Type_id.ToString() ?? "User"),
                    new Claim("CorporateId", userMaster.Corporate?.Corporate_Id.ToString() ?? "User"),
                    new Claim("UserRoleId", userMaster.UserRole?.User_Role_id.ToString() ?? "User"),
                    new Claim("UserLoginId", userMaster.User_Login_id.ToString() ?? "User"),
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new LoginResponse{ Token = tokenString, UserName = user.UserName };
        }
    }
}
