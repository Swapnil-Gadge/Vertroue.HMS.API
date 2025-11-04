using Azure.Core;
using System.Security.Claims;
using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Application.Extensions;
using Vertroue.HMS.API.Application.Shared;

namespace Vertroue.HMS.API.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public string? UserId
        {
            get
            {      
                return _contextAccessor.HttpContext?.User?.Identity?.Name;
            }
        }

        public string UserRole
        {
            get
            {
                return (_contextAccessor.HttpContext?.User?.Identity as ClaimsIdentity)
                    .Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? string.Empty;
            }
        }

        public int HospitalId
        {
            get
            {
                return (_contextAccessor.HttpContext?.User?.Identity as ClaimsIdentity)
                    .Claims.FirstOrDefault(c => c.Type == "HospitalId")?.Value.ToInt32() ?? 0;
            }
        }

        public string? UserName
        {
            get
            {
                return (_contextAccessor.HttpContext?.User?.Identity as ClaimsIdentity)
                    .Claims.FirstOrDefault(c => c.Type == "UserName")?.Value.ToString() ?? null;
            }
        }

        public int CorporateId
        {
            get
            {
                return (_contextAccessor.HttpContext?.User?.Identity as ClaimsIdentity)
                    .Claims.FirstOrDefault(c => c.Type == "CorporateId")?.Value.ToInt32() ?? 0;
            }
        }

        public int UserLoginId
        {
            get
            {
                return (_contextAccessor.HttpContext?.User?.Identity as ClaimsIdentity)
                    .Claims.FirstOrDefault(c => c.Type == "UserLoginId")?.Value.ToInt32() ?? 0;
            }
        }

        public string UserType
        {
            get
            {
                return (_contextAccessor.HttpContext?.User?.Identity as ClaimsIdentity)
                    .Claims.FirstOrDefault(c => c.Type == "UserTypeName")?.Value ?? string.Empty;
            }
        }

        public bool IsUserUnauthorizedToPerformOperation(int hospitalId)
        {
            return this.HospitalId != hospitalId && UserRole != Constant.UserRoles.ProviderAdmin;
        }
    }
}
