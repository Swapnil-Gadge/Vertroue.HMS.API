using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Commands;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Model;
using Vertroue.HMS.API.Application.Features.QMS.FileSentTPA.Queries;
using Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Commands;
using Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Model;
using Vertroue.HMS.API.Application.Features.QMS.PaymentReceived.Queries;
using Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Add;
using Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Enhancement;
using Vertroue.HMS.API.Application.Features.QMS.QMSCase.Commands.Update;
using Vertroue.HMS.API.Application.Features.QMS.QMSControl.Model;
using Vertroue.HMS.API.Application.Features.QMS.QMSControl.Queries;

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

        public async Task<FetchPaymentReceivedResponse> FetchCorporatePendingPaymentReceivedAsync(GetPaymentReceivedQuery request)
        {
            var result = new FetchPaymentReceivedResponse
            {
                PendingPayments = new(),
                Statuses = new(),
                Estimations = new(),
                Trackers = new(),
                CaseTypes = new()
            };

            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("FetchCorporate_Pending_Reciev", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);
            cmd.Parameters.AddWithValue("@UserId", request.UserId);
            cmd.Parameters.AddWithValue("@UserType", request.UserType);
            cmd.Parameters.AddWithValue("@UserRole", request.UserRole);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            // Result Set 1: PendingPayments
            while (await reader.ReadAsync())
            {
                result.PendingPayments.Add(new PaymentReceivedCaseDto
                {
                    TblId = Convert.ToInt32(reader["tbl_id"]),
                    CaseId = Convert.ToInt32(reader["Case_id"]),
                    InsurerId = Convert.ToInt32(reader["Insurer_Id"]),
                    InsurerName = reader["Insurer_Name"]?.ToString(),
                    TpaId = Convert.ToInt32(reader["TPA_id"]),
                    TpaName = reader["TPA_Name"]?.ToString(),
                    PatientName = reader["Patient_Name"]?.ToString(),
                    DOA = reader["DOA"]?.ToString(),
                    ActualDOD = reader["Actual_DOD"]?.ToString(),
                    TotalApprovedAmt = Convert.ToDecimal(reader["Total_Approved_amt"]),
                    CaseFileSentDate = reader["Case_File_Sent_date"]?.ToString(),
                    PaymentStatus = reader["Payment_Status"]?.ToString(),
                    CaseDetailsId = Convert.ToInt32(reader["Case_Details_id"])
                });
            }

            await reader.NextResultAsync(); // Result Set 2: Statuses
            while (await reader.ReadAsync())
            {
                result.Statuses.Add(new PaymentReceivedStatusDto
                {
                    StatusId = Convert.ToInt32(reader["Status_id"]),
                    StatusName = reader["Status_Name"]?.ToString()
                });
            }

            await reader.NextResultAsync(); // Result Set 3: Estimations
            while (await reader.ReadAsync())
            {
                result.Estimations.Add(new PaymentReceivedEstimationDto
                {
                    TblId = Convert.ToInt32(reader["tbl_id"]),
                    CaseId = Convert.ToInt32(reader["Case_id"]),
                    CorporateId = Convert.ToInt32(reader["Corporate_id"]),
                    CorporateName = reader["Corporate_name"]?.ToString(),
                    InsurerId = Convert.ToInt32(reader["Insurer_Id"]),
                    InsurerName = reader["Insurer_name"]?.ToString(),
                    TpaId = Convert.ToInt32(reader["TPA_id"]),
                    TpaName = reader["TPA_Name"]?.ToString(),
                    CaseDetailsId = Convert.ToInt32(reader["Case_Details_id"]),
                    DOA = reader["DOA"]?.ToString(),
                    ExpectedDOD = reader["Expected_DOD"]?.ToString(),
                    NoDaysOfStay = Convert.ToInt32(reader["No_days_Of_Stay"]),
                    ActualDOD = reader["Actual_DOD"]?.ToString(),
                    EstimatedAmount = Convert.ToDecimal(reader["Estimated_Amount"])
                });
            }

            await reader.NextResultAsync(); // Result Set 4: Trackers
            while (await reader.ReadAsync())
            {
                result.Trackers.Add(new PaymentReceivedTrackerDto
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

            await reader.NextResultAsync(); // Result Set 5: CaseTypes
            while (await reader.ReadAsync())
            {
                result.CaseTypes.Add(new PaymentReceivedCaseTypeDto
                {
                    CaseTypeCode = reader["Case_Type_code"]?.ToString(),
                    CaseTypeName = reader["Case_Type_Name"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> UpdateCorporatePendingPaymentReceivedAsync(UpdateCorporatePendingPaymentReceivedCommand command)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("UpdateCorporate_Pending_Reciev", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", command.UserId);
            cmd.Parameters.AddWithValue("@UserType", command.UserType);
            cmd.Parameters.AddWithValue("@UserRole", command.UserRole);
            cmd.Parameters.AddWithValue("@Corporate_id", command.CorporateId);
            cmd.Parameters.AddWithValue("@Case_id", command.CaseId);
            cmd.Parameters.AddWithValue("@Status_id", command.StatusId);
            cmd.Parameters.AddWithValue("@Status_remarks", command.StatusRemark ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Urtno", command.Urtno ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@pay_rec_amt", command.PayReceivedAmount ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@tds_amount", command.TdsAmount ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@tdsPer", command.TdsPercentage ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@tds_rec_date", command.TdsReceivedDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Pay_remarks", command.PaymentRemarks ?? (object)DBNull.Value);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return reader[0].ToString();

            return "No response";
        }

        public async Task<FetchAllQMSControlsListResponse> FetchAllQMSControlsListAsync(int userId, string userType, string userRole, int corporateId)
        {
            var result = new FetchAllQMSControlsListResponse();

            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("FetchAllQMScontorlsList", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@UserType", userType);
            cmd.Parameters.AddWithValue("@UserRole", userRole);
            cmd.Parameters.AddWithValue("@Corporate_Id", corporateId);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            async Task ReadList<T>(List<T> list, Func<SqlDataReader, T> map)
            {
                while (await reader.ReadAsync())
                {
                    list.Add(map(reader));
                }
            }

            await ReadList(result.Insurers, r => new QMSInsurerDto
            {
                InsurerId = Convert.ToInt32(r["insurer_id"]),
                InsurerName = r["insurer_name"]?.ToString()
            });

            await reader.NextResultAsync();
            await ReadList(result.TPAs, r => new QMSTPADto
            {
                TPAId = Convert.ToInt32(r["TPA_Id"]),
                TPAName = r["TP_Name"]?.ToString()
            });

            await reader.NextResultAsync();
            await ReadList(result.Relations, r => new QMSRelationDto
            {
                RelationId = Convert.ToInt32(r["relation_id"]),
                RelationName = r["relation_name"]?.ToString()
            });

            await reader.NextResultAsync();
            await ReadList(result.Genders, r => new QMSGenderDto
            {
                GenderId = Convert.ToInt32(r["Gender_id"]),
                GenderName = r["Gender_Name"]?.ToString()
            });

            await reader.NextResultAsync();
            await ReadList(result.IdentificationTypes, r => new QMSIdentificationTypeDto
            {
                IdentificationTypeId = Convert.ToInt32(r["Identification_Type_id"]),
                IdentificationTypeName = r["Identification_Type_Name"]?.ToString()
            });

            await reader.NextResultAsync();
            await ReadList(result.AdmissionTypes, r => new QMSAdmissionTypeDto
            {
                AdmissionTypeId = Convert.ToInt32(r["Admission_Type_id"]),
                AdmissionTypeName = r["Admission_Type_Name"]?.ToString()
            });

            await reader.NextResultAsync();
            await ReadList(result.Statuses, r => new QMSStatusControlDto
            {
                StatusId = Convert.ToInt32(r["Status_id"]),
                StatusName = r["Status_Name"]?.ToString()
            });

            await reader.NextResultAsync();
            await ReadList(result.CaseTypes, r => new QMSCaseTypeControlDto
            {
                CaseTypeCode = r["Case_Type_code"]?.ToString(),
                CaseTypeName = r["Case_Type_Name"]?.ToString()
            });

            async Task ReadPatientList(List<QMSPatientDto> list)
            {
                while (await reader.ReadAsync())
                {
                    list.Add(new QMSPatientDto
                    {
                        CaseId = Convert.ToInt32(reader["case_id"]),
                        PatientName = reader["Patient_Name"]?.ToString(),
                        PatientMobileNo = reader["Patient_Mobile_No"]?.ToString(),
                        PatientEmailId = reader["Patient_Email_id"]?.ToString(),
                        PatientGender = reader["Patient_Gender"]?.ToString(),
                        RelationName = reader["Relation_Name"]?.ToString(),
                        StatusName = reader["Status_name"]?.ToString(),
                        StatusId = Convert.ToInt32(reader["status_id"]),
                        CaseDetailsId = Convert.ToInt32(reader["Case_Details_id"])
                    });
                }
            }

            async Task ReadDynamicList(List<QMSDynamicDataDto> list)
            {
                while (await reader.ReadAsync())
                {
                    list.Add(new QMSDynamicDataDto
                    {
                        TblId = Convert.ToInt32(reader["tbl_id"]),
                        CaseId = Convert.ToInt32(reader["case_id"]),
                        ColumnName = reader["Column_Name"]?.ToString(),
                        ColumnDetails = reader["Column_Details"]?.ToString(),
                        ColumnName1 = reader["Column_Name1"]?.ToString(),
                        ColumnDetails1 = reader["Column_Details1"]?.ToString()
                    });
                }
            }

            await reader.NextResultAsync(); await ReadPatientList(result.PatientList1);
            await reader.NextResultAsync(); await ReadDynamicList(result.DynamicData1);

            await reader.NextResultAsync(); await ReadPatientList(result.PatientList2);
            await reader.NextResultAsync(); await ReadDynamicList(result.DynamicData2);

            await reader.NextResultAsync(); await ReadPatientList(result.PatientList3);
            await reader.NextResultAsync(); await ReadDynamicList(result.DynamicData3);

            await reader.NextResultAsync(); await ReadPatientList(result.PatientList4);
            await reader.NextResultAsync(); await ReadDynamicList(result.DynamicData4);

            return result;
        }

        public async Task<string> CreateQMSCaseAsync(CreateQMSCaseCommand req)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("QMSCreateCase", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@AabhaNo", req.AabhaNo ?? string.Empty);
            cmd.Parameters.AddWithValue("@IdentityficationType", req.IdentityficationType);
            cmd.Parameters.AddWithValue("@Indentification", req.Indentification ?? string.Empty);
            cmd.Parameters.AddWithValue("@insurer", req.Insurer);
            cmd.Parameters.AddWithValue("@tpa", req.Tpa);
            cmd.Parameters.AddWithValue("@patientname", req.PatientName ?? string.Empty);
            cmd.Parameters.AddWithValue("@policyholdername", req.PolicyHolderName ?? string.Empty);
            cmd.Parameters.AddWithValue("@gender", req.Gender);
            cmd.Parameters.AddWithValue("@addmissiontype", req.AddmissionType);
            cmd.Parameters.AddWithValue("@relation", req.Relation);
            cmd.Parameters.AddWithValue("@filepath", req.FilePath ?? string.Empty);
            cmd.Parameters.AddWithValue("@mobile", req.Mobile ?? string.Empty);
            cmd.Parameters.AddWithValue("@email", req.Email ?? string.Empty);
            cmd.Parameters.AddWithValue("@status", req.Status);
            cmd.Parameters.AddWithValue("@ststusremarks", req.StatusRemarks ?? string.Empty);
            cmd.Parameters.AddWithValue("@UserId", req.UserId);
            cmd.Parameters.AddWithValue("@Corporate_id", req.CorporateId);
            cmd.Parameters.AddWithValue("@PrevConsulNote", req.PrevConsulNote ?? string.Empty);
            cmd.Parameters.AddWithValue("@PolicyNo", req.PolicyNo ?? string.Empty);
            cmd.Parameters.AddWithValue("@Case_type", req.CaseType ?? string.Empty);
            cmd.Parameters.AddWithValue("@UserRole", req.UserRole ?? string.Empty);
            cmd.Parameters.AddWithValue("@UserType", req.UserType ?? string.Empty);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return result?.ToString() ?? "No response";
        }

        public async Task<string> UpdateQMSCaseDetailsAsync(UpdateQMSCaseCommand req)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("QMSUpdateCase", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Status_id", req.StatusId);
            cmd.Parameters.AddWithValue("@Case_id", req.CaseId);
            cmd.Parameters.AddWithValue("@DOA", req.DOA ?? string.Empty);
            cmd.Parameters.AddWithValue("@DOD", req.DOD ?? string.Empty);
            cmd.Parameters.AddWithValue("@ClaimedAmount", req.ClaimAmount ?? string.Empty);
            cmd.Parameters.AddWithValue("@claimDocPath", req.ClaimDocPath ?? string.Empty);
            cmd.Parameters.AddWithValue("@Status_Remarks", req.StatusRemark ?? string.Empty);
            cmd.Parameters.AddWithValue("@UserId", req.UserId);
            cmd.Parameters.AddWithValue("@UserRole", req.UserRole ?? string.Empty);
            cmd.Parameters.AddWithValue("@UserType", req.UserType ?? string.Empty);
            cmd.Parameters.AddWithValue("@Corporate_id", req.CorporateId);
            cmd.Parameters.AddWithValue("@Case_Details_id", req.CaseDetailsId);
            cmd.Parameters.AddWithValue("@Approved_amt", req.ApprovedAmt ?? "0");
            cmd.Parameters.AddWithValue("@Approval_Remarks", req.ApprovalRemarks ?? string.Empty);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return result?.ToString() ?? "No response";
        }

        public async Task<string> UpdateCaseEnhancementAsync(UpdateCaseEnhancementCommand req)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("QMSCreateCaseEnhancement", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Case_Details_id", req.CaseDetailsId);
            cmd.Parameters.AddWithValue("@Case_id", req.CaseId);
            cmd.Parameters.AddWithValue("@DOA", req.DOA ?? string.Empty);
            cmd.Parameters.AddWithValue("@DOD", req.DOD ?? string.Empty);
            cmd.Parameters.AddWithValue("@ClaimedAmount", req.ClaimAmount ?? "0");
            cmd.Parameters.AddWithValue("@claimDocPath", req.ClaimDocPath ?? string.Empty);
            cmd.Parameters.AddWithValue("@CaseType", req.CaseType ?? string.Empty);
            cmd.Parameters.AddWithValue("@UserId", req.UserId);
            cmd.Parameters.AddWithValue("@UserRole", req.UserRole ?? string.Empty);
            cmd.Parameters.AddWithValue("@UserType", req.UserType ?? string.Empty);
            cmd.Parameters.AddWithValue("@Corporate_Id", req.CorporateId);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return result?.ToString() ?? "No response";
        }
    }
}
