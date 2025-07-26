using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Reports.Model;
using Vertroue.HMS.API.Application.Features.Reports.Queries;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IConfiguration _config;

        public ReportRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<CorporateCasePendingReportDto>> FetchCorporateCasePendingReportAsync(GetCorporateCasePendingReportQuery request)
        {
            var result = new List<CorporateCasePendingReportDto>();
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("FetchCorporate_CasePending_Reports", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);
            cmd.Parameters.AddWithValue("@UserId", request.UserId);
            cmd.Parameters.AddWithValue("@UserType", request.UserType);
            cmd.Parameters.AddWithValue("@UserRole", request.UserRole);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new CorporateCasePendingReportDto
                {
                    TblId = reader["tbl_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["tbl_id"]),
                    CaseId = reader["Case_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Case_id"]),
                    InsurerId = reader["Insurer_Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Insurer_Id"]),
                    InsurerName = reader["Insurer_Name"] == DBNull.Value ? string.Empty : reader["Insurer_Name"].ToString(),
                    TPAId = reader["TPA_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TPA_id"]),
                    TPAName = reader["TPA_Name"] == DBNull.Value ? string.Empty : reader["TPA_Name"].ToString(),
                    PatientName = reader["Patient_Name"] == DBNull.Value ? string.Empty : reader["Patient_Name"].ToString(),
                    MobileNo = reader["Mobile_no"] == DBNull.Value ? string.Empty : reader["Mobile_no"].ToString(),
                    EmailId = reader["Email_id"] == DBNull.Value ? string.Empty : reader["Email_id"].ToString(),
                    Gender = reader["Gender"] == DBNull.Value ? string.Empty : reader["Gender"].ToString(),
                    Relation = reader["Relation"] == DBNull.Value ? string.Empty : reader["Relation"].ToString(),
                    AdmissionType = reader["Addmission_type"] == DBNull.Value ? string.Empty : reader["Addmission_type"].ToString(),
                    DOA = reader["DOA"] == DBNull.Value ? string.Empty : reader["DOA"].ToString(),
                    ExpectedDOD = reader["Expected_DOD"] == DBNull.Value ? string.Empty : reader["Expected_DOD"].ToString(),
                    NoOfDays = reader["No_of_days"] == DBNull.Value ? 0 : Convert.ToInt32(reader["No_of_days"]),
                    ActualDOD = reader["Actual_DOD"] == DBNull.Value ? string.Empty : reader["Actual_DOD"].ToString(),
                    EstimatedAmount = reader["Estimated_Amount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Estimated_Amount"]),
                    PreviousConsultationNotes = reader["Previouse_Consultation_Notes"] == DBNull.Value ? string.Empty : reader["Previouse_Consultation_Notes"].ToString(),
                    ApprovalAmount = reader["Approval_Amount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Approval_Amount"]),
                    ApprovalRemarks = reader["Approval_Remarks"] == DBNull.Value ? string.Empty : reader["Approval_Remarks"].ToString(),
                    DeductionAmount = reader["Deduction_Amount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Deduction_Amount"]),
                    DeductionRemarks = reader["Deduction_Remarks"] == DBNull.Value ? string.Empty : reader["Deduction_Remarks"].ToString(),
                    CaseStatus = reader["Case_status"] == DBNull.Value ? string.Empty : reader["Case_status"].ToString()
                });
            }

            return result;
        }
    }
}
