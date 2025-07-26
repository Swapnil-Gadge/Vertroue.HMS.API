using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Users.Model;
using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    public class UserMasterRepository : BaseRepository<UserMaster>, IUserMasterRepository
    {
        private readonly IConfiguration _config;
        public UserMasterRepository(ApiDbContext dbContext, IConfiguration config) : base(dbContext)
        {
            _config = config;
        }

        public async Task<UserMaster> GetUserDetails(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("Username is empty");

            return await _dbContext.User_Master
                .Include(u => u.Corporate)
                .Include(u => u.UserRole)
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower());
        }

        public async Task<LoginResponseDto> ValidateLoginAsync(string userId, string password, string userType)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("ValidateLogin", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@UserPass", password);
            cmd.Parameters.AddWithValue("@UserType", userType);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync()) return null;

            if (reader.FieldCount == 1 && reader[0]?.ToString() == "Invalid")
                return null;

            return new LoginResponseDto
            {
                UserLoginId = reader["User_Login_id"] != DBNull.Value ? Convert.ToInt32(reader["User_Login_id"]) : 0,
                CorporateId = reader["Corporate_Id"] != DBNull.Value ? Convert.ToInt32(reader["Corporate_Id"]) : 0,
                UserTypeId = reader["User_Type_id"] != DBNull.Value ? Convert.ToInt32(reader["User_Type_id"]) : 0,
                UserRoleId = reader["User_Role_id"] != DBNull.Value ? Convert.ToInt32(reader["User_Role_id"]) : 0,
                UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : string.Empty,
                UserRoleName = reader["User_role_Name"] != DBNull.Value ? reader["User_role_Name"].ToString() : string.Empty,
                UserTypeName = reader["User_Type_Name"] != DBNull.Value ? reader["User_Type_Name"].ToString() : string.Empty,
                PasswordExpireFlag = reader["PasswordExpire_flag"] != DBNull.Value && Convert.ToBoolean(reader["PasswordExpire_flag"]),
                LastChangePasswordDate = reader["Last_change_Pass_Date"] != DBNull.Value ? reader["Last_change_Pass_Date"].ToString() : string.Empty,
                UserSessionId = reader["User_SessionId"] != DBNull.Value ? reader["User_SessionId"].ToString() : string.Empty,
                CorporateIdAgain = reader["Corporate_Id"] != DBNull.Value ? Convert.ToInt32(reader["Corporate_Id"]) : 0,
                CorporateName = reader["Corporate_Name"] != DBNull.Value ? reader["Corporate_Name"].ToString() : string.Empty,
                CorporateType = reader["Corporate_Type"] != DBNull.Value ? reader["Corporate_Type"].ToString() : string.Empty,
                ServiceActiveFlag = reader["Service_Active_Flag"] != DBNull.Value ? reader["Service_Active_Flag"].ToString() : string.Empty,
                ServiceStartDate = reader["Service_Start_Date"] != DBNull.Value ? reader["Service_Start_Date"].ToString() : string.Empty,
                ServiceEndDate = reader["Service_End_Date"] != DBNull.Value ? reader["Service_End_Date"].ToString() : string.Empty,
                ServiceLapsedFlag = reader["Service_Lapsed_flag"] != DBNull.Value ? reader["Service_Lapsed_flag"].ToString() : string.Empty

            };
        }

        public async Task<bool> UpdatePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var connection = new SqlConnection(connStr);
            using var command = new SqlCommand("sp_UpdatePassword", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@UserID", userId);
            command.Parameters.AddWithValue("@OldPassword", oldPassword);
            command.Parameters.AddWithValue("@NewPassword", newPassword);

            await connection.OpenAsync();
            int rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }
    }
}
