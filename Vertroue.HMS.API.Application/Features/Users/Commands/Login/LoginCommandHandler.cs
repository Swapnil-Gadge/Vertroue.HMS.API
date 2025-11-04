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
                PasswordHash = userMaster.Password
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
                    new Claim(ClaimTypes.Role, userMaster.UserRole?.Name ?? "GUEST"),
                    new Claim("HospitalID", userMaster.HospitalId?.ToString() ?? "NONE"),
                    new Claim("UserName", userMaster.Name ?? "No NAME"),
                    }),
                Expires = DateTime.Now.AddHours(14),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new LoginResponse { 
                Token = tokenString, 
                UserName = user.UserName, 
                UserRole = userMaster.UserRole?.Name ?? "GUEST",
                HospitalId = userMaster.HospitalId ?? 0,
                FullName = userMaster.Name ?? string.Empty,
                HospitalName = userMaster.Hospital?.Name ?? string.Empty,                
            };
        }
    }
}
