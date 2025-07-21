using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Billing.PaidCases.Models;
using Vertroue.HMS.API.Application.Features.Billing.PendingCases.Models;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        private readonly IConfiguration _config;

        public BillingRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<PendingCaseDto>> GetPendingPaymentCasesAsync(int corporateId, int userId, string userType, string userRole)
        {
            var result = new List<PendingCaseDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("FetchCorporate_Pending_Payments", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@UserType", userType);
                cmd.Parameters.AddWithValue("@UserRole", userRole);
                cmd.Parameters.AddWithValue("@Corporate_id", corporateId);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result.Add(new PendingCaseDto
                        {
                            CaseId = reader.GetInt32(reader.GetOrdinal("CaseId")),
                            PatientName = reader.GetString(reader.GetOrdinal("PatientName")),
                            PendingAmount = reader.GetDecimal(reader.GetOrdinal("PendingAmount")),
                            Status = reader.GetString(reader.GetOrdinal("Status"))
                        });
                    }
                }
            }

            return result;
        }

        public async Task<List<PaidCaseDto>> GetPaidCasesAsync(int corporateId, int userId, string userType, string userRole)
        {
            var result = new List<PaidCaseDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("FetchCorporate_Paid_Payments", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@UserType", userType);
                cmd.Parameters.AddWithValue("@UserRole", userRole);
                cmd.Parameters.AddWithValue("@Corporate_id", corporateId);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result.Add(new PaidCaseDto
                        {
                            CaseId = reader.GetInt32(reader.GetOrdinal("CaseId")),
                            PatientName = reader.GetString(reader.GetOrdinal("PatientName")),
                            Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                            Status = reader.GetString(reader.GetOrdinal("Status"))
                        });
                    }
                }
            }

            return result;
        }
    }

}
