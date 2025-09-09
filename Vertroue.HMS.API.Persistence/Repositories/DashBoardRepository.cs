using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Dashboards.Models;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    public class DashBoardRepository : IDashBoardRepository
    {
        private readonly ApiDbContext _context;

        public DashBoardRepository(ApiDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<(List<CaseCounts>, List<TatReportCase>, List<Denial>, List<Defficiency>, List<string?>, List<string?>)> GetProviderAdminDashboardData(int corpId, int loginId, string userType, string userRole)
        {
            var caseCounts = new List<CaseCounts>();
            var tatReportCases = new List<TatReportCase>();
            var denials = new List<Denial>();
            var defficiencies = new List<Defficiency>();
            var tatReport = new List<string?>();
            var totalCaseBiFurications = new List<string?>();

            var connection = _context.Database.GetDbConnection();
            await using (connection)
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DashBoard_Provider";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] spParameter = new SqlParameter[4];

                    spParameter[0] = new SqlParameter("@UserId", SqlDbType.Int);
                    spParameter[0].Direction = ParameterDirection.Input;
                    spParameter[0].Value = loginId;

                    spParameter[1] = new SqlParameter("@UserType", SqlDbType.VarChar, 100);
                    spParameter[1].Direction = ParameterDirection.Input;
                    spParameter[1].Value = userType;

                    spParameter[2] = new SqlParameter("@UserRole", SqlDbType.VarChar, 100);
                    spParameter[2].Direction = ParameterDirection.Input;
                    spParameter[2].Value = userRole;

                    spParameter[3] = new SqlParameter("@Corporate_id", SqlDbType.Int);
                    spParameter[3].Direction = ParameterDirection.Input;
                    spParameter[3].Value = corpId;

                    command.Parameters.AddRange(spParameter);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        // Read first result set
                        while (await reader.ReadAsync())
                        {
                            caseCounts.Add(new CaseCounts
                            {
                                LiveCaseCount = reader.IsDBNull(0) ? null : reader.GetInt32(0),
                                LiveCasePercent = reader.IsDBNull(1) ? null : Convert.ToDecimal(reader.GetValue(1)),
                                LiveCaseAmount = reader.IsDBNull(2) ? null : Convert.ToDecimal(reader.GetValue(2)),
                                ApprovedCaseCount = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                                ApprovedCasePercent = reader.IsDBNull(4) ? null : Convert.ToDecimal(reader.GetValue(4)),
                                ApprovedCaseAmount = reader.IsDBNull(5) ? null : Convert.ToDecimal(reader.GetValue(5)),
                                QuerryCaseCount = reader.IsDBNull(6) ? null : reader.GetInt32(6),
                                QuerryCasePercent = reader.IsDBNull(7) ? null : Convert.ToDecimal(reader.GetValue(7)),
                                QuerryCaseAmount = reader.IsDBNull(8) ? null : Convert.ToDecimal(reader.GetValue(8)),
                                DeniedCaseCount = reader.IsDBNull(9) ? null : reader.GetInt32(9),
                                DeniedCasePercent = reader.IsDBNull(10) ? null : Convert.ToDecimal(reader.GetValue(10)),
                                DeniedCaseAmount = reader.IsDBNull(11) ? null : Convert.ToDecimal(reader.GetValue(11)),
                                DischargeCaseCount = reader.IsDBNull(12) ? null : reader.GetInt32(12),
                                DischargeCasePercent = reader.IsDBNull(13) ? null : Convert.ToDecimal(reader.GetValue(13)),
                                DischargeCaseAmount = reader.IsDBNull(14) ? null : Convert.ToDecimal(reader.GetValue(14)),
                                PaidCaseCount = reader.IsDBNull(15) ? null : reader.GetInt32(15),
                                PaidCasePercent = reader.IsDBNull(16) ? null : Convert.ToDecimal(reader.GetValue(16)),
                                PaidCaseAmount = reader.IsDBNull(17) ? null : Convert.ToDecimal(reader.GetValue(17)),
                                PayPendingCaseCount = reader.IsDBNull(18) ? null : reader.GetInt32(18),
                                PayPendingCasePercent = reader.IsDBNull(19) ? null : Convert.ToDecimal(reader.GetValue(19)),
                                PayPendingCaseAmount = reader.IsDBNull(20) ? null : Convert.ToDecimal(reader.GetValue(20)),
                                FileSentCaseCount = reader.IsDBNull(21) ? null : reader.GetInt32(21),
                                FileSentCasePercent = reader.IsDBNull(22) ? null : Convert.ToDecimal(reader.GetValue(22)),
                                FileSentCaseAmount = reader.IsDBNull(23) ? null : Convert.ToDecimal(reader.GetValue(23)),
                                TotalCaseCount = reader.IsDBNull(24) ? null : reader.GetInt32(24),
                                TotalCasePercent = reader.IsDBNull(25) ? null : Convert.ToDecimal(reader.GetValue(25)),
                                TotalCaseAmount = reader.IsDBNull(26) ? null : Convert.ToDecimal(reader.GetValue(26)),                                
                            });
                        }

                        // Go to the next result set
                        if (await reader.NextResultAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                tatReportCases.Add(new TatReportCase
                                {
                                    TableId = reader.GetInt32(0), 
                                    CaseDetailsId = reader.IsDBNull(1) ? null : reader.GetInt32(1),
                                    CaseInitiateDate = reader.IsDBNull(2) ? null : reader.GetDateTime(2),
                                    CaseDeffRecvDate = reader.IsDBNull(3) ? null : reader.GetDateTime(3),
                                    CaseDeffRespDate = reader.IsDBNull(4) ? null : reader.GetDateTime(4),
                                    CaseApprovalDate = reader.IsDBNull(5) ? null : reader.GetDateTime(5),
                                    CaseDeffTat = reader.IsDBNull(6) ? null : Convert.ToDecimal(reader.GetValue(6)),
                                    CaseApprTat = reader.IsDBNull(7) ? null : Convert.ToDecimal(reader.GetValue(7)),
                                    TatInHrs = reader.IsDBNull(8) ? null : Convert.ToDecimal(reader.GetValue(8)),
                                });
                            }
                        }

                        if (await reader.NextResultAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                tatReport.Add(reader.IsDBNull(0) ? null : reader.GetString(0));
                            }
                        }

                        if (await reader.NextResultAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                totalCaseBiFurications.Add(reader.IsDBNull(0) ? null : reader.GetString(0));
                            }
                        }

                        if (await reader.NextResultAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                defficiencies.Add(new Defficiency
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                                    TPACode = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    InsurerCode = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Count = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                                });
                            }
                        }

                        if (await reader.NextResultAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                denials.Add(new Denial
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                                    TPACode = reader.IsDBNull(2) ? null : reader.GetString(2),
                                    InsurerCode = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Count = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                                });
                            }
                        }
                    }
                }
            }

            totalCaseBiFurications.Reverse();
            return (caseCounts, tatReportCases, denials, defficiencies, tatReport, totalCaseBiFurications);
        }
    }
}
