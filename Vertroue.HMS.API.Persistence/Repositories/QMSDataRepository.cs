using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Commands;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Model;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Queries;

namespace Vertroue.HMS.API.Persistence.Repositories
{    public class QMSDataRepository : IQMSDataRepository
    {
        private readonly IConfiguration _config;

        public QMSDataRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<GetCorporatePendingFileSentResponse> FetchCorporatePendingFileSentAsync(int corporateId, int userId, string userType, string userRole)
        {
            var result = new GetCorporatePendingFileSentResponse
            {
                MainRecords = new(),
                StatusList = new(),
                CaseDetails = new(),
                StatusTracker = new(),
                CaseTypes = new()
            };

            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("FetchCorporate_Pending_fileSent", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Corporate_id", corporateId);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@UserType", userType);
            cmd.Parameters.AddWithValue("@UserRole", userRole);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            // Result Set 1
            while (await reader.ReadAsync())
            {
                result.MainRecords.Add(new QMSMainRecordDto
                {
                    TblId = Convert.ToInt32(reader["tbl_id"]),
                    CaseId = Convert.ToInt32(reader["Case_id"]),
                    InsurerId = Convert.ToInt32(reader["Insurer_Id"]),
                    InsurerName = reader["Insurer_Name"]?.ToString(),
                    TPAId = Convert.ToInt32(reader["TPA_id"]),
                    TPAName = reader["TPA_Name"]?.ToString(),
                    PatientName = reader["Patient_Name"]?.ToString(),
                    DOA = reader["DOA"]?.ToString(),
                    ActualDOD = reader["Actual_DOD"]?.ToString(),
                    TotalApprovedAmount = Convert.ToDecimal(reader["Total_Approved_amt"]),
                    CaseFileSentDate = reader["Case_File_Sent_date"]?.ToString(),
                    PaymentStatus = reader["Payment_Status"]?.ToString(),
                    CaseDetailsId = Convert.ToInt32(reader["Case_Details_id"])
                });
            }

            await reader.NextResultAsync(); // Result Set 2
            while (await reader.ReadAsync())
            {
                result.StatusList.Add(new QMSStatusDto
                {
                    StatusId = Convert.ToInt32(reader["Status_id"]),
                    StatusName = reader["Status_Name"]?.ToString()
                });
            }

            await reader.NextResultAsync(); // Result Set 3
            while (await reader.ReadAsync())
            {
                result.CaseDetails.Add(new QMSCaseDetailsDto
                {
                    TblId = Convert.ToInt32(reader["tbl_id"]),
                    CaseId = Convert.ToInt32(reader["Case_id"]),
                    CorporateId = Convert.ToInt32(reader["Corporate_id"]),
                    CorporateName = reader["Corporate_name"]?.ToString(),
                    InsurerId = Convert.ToInt32(reader["Insurer_Id"]),
                    InsurerName = reader["Insurer_name"]?.ToString(),
                    TPAId = Convert.ToInt32(reader["TPA_id"]),
                    TPAName = reader["TPA_Name"]?.ToString(),
                    CaseDetailsId = Convert.ToInt32(reader["Case_Details_id"]),
                    DOA = reader["DOA"]?.ToString(),
                    ExpectedDOD = reader["Expected_DOD"]?.ToString(),
                    NoOfDaysStay = Convert.ToInt32(reader["No_days_Of_Stay"]),
                    ActualDOD = reader["Actual_DOD"]?.ToString(),
                    EstimatedAmount = Convert.ToDecimal(reader["Estimated_Amount"])
                });
            }

            await reader.NextResultAsync(); // Result Set 4
            while (await reader.ReadAsync())
            {
                result.StatusTracker.Add(new QMSStatusTrackerDto
                {
                    TblId = Convert.ToInt32(reader["tbl_id"]),
                    CaseStatusTrackerId = Convert.ToInt32(reader["Case_Status_Tracker_id"]),
                    StatusId = Convert.ToInt32(reader["Status_id"]),
                    StatusName = reader["Status_name"]?.ToString(),
                    StatusRemarks = reader["Status_Remarks"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_By"]?.ToString(),
                    DocumentLink = reader["Document_link"]?.ToString()
                });
            }

            await reader.NextResultAsync(); // Result Set 5
            while (await reader.ReadAsync())
            {
                result.CaseTypes.Add(new QMSCaseTypeDto
                {
                    CaseTypeCode = reader["Case_Type_code"]?.ToString(),
                    CaseTypeName = reader["Case_Type_Name"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> UpdateCorporatePendingFileSentAsync(UpdateCorporateFileSentCommand request)
        {
            string result = "Failed";
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("UpdateCorporate_Pending_fileSent", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", request.UserId);
            cmd.Parameters.AddWithValue("@UserType", request.UserType);
            cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
            cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);
            cmd.Parameters.AddWithValue("@Case_id", request.CaseId);
            cmd.Parameters.AddWithValue("@Status_id", request.StatusId);
            cmd.Parameters.AddWithValue("@Status_remarks", request.StatusRemark);
            cmd.Parameters.AddWithValue("@File_sent_date", request.FileSentDate);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result = reader[0]?.ToString() ?? "Success";
            }

            return result;
        }
    }
}
