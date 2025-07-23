using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Add;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.AddInsurerRates;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Commands.Modify;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Model;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurer.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateInsurerRates.Model;
using Vertroue.HMS.API.Application.Features.Corporate.CorporateMou.Model;
using Vertroue.HMS.API.Application.Features.Corporate.Details.Model;
using Vertroue.HMS.API.Application.Features.Corporate.Details.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.AddCorporateUser;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Commands.ModifyCorporateUser;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Model;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.List.Models;
using Vertroue.HMS.API.Application.Features.Corporate.List.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Commands;
using Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Model;
using Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.Renewal.Commands;
using Vertroue.HMS.API.Application.Features.Corporate.Renewal.Model;
using Vertroue.HMS.API.Application.Features.Corporate.Renewal.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.AddCorporateTPA;
using Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.DeactivateCorporateTPACommand;
using Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.InsertCorporateTPARates;
using Vertroue.HMS.API.Application.Features.Corporate.TPA.Commands.ModifyCorporateTPA;
using Vertroue.HMS.API.Application.Features.Corporate.TPA.Model;
using Vertroue.HMS.API.Application.Features.Corporate.TPA.Queries.CorporateTPA;
using Vertroue.HMS.API.Application.Features.Corporate.TPA.Queries.CorporateTPARates;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    public class CorporateRepository : ICorporateRepository
    {
        private readonly IConfiguration _config;

        public CorporateRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<FetchParentCorporateResponse> GetParentCorporateWithDetailsAsync(int userId, string userType, string userRole)
        {
            var response = new FetchParentCorporateResponse
            {
                ParentCorporates = new List<ParentCorporateDto>(),
                CaseDetails = new List<ParentCorporateDetailsDto>()
            };

            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("FetchParentCorporate", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@UserType", userType);
                cmd.Parameters.AddWithValue("@UserRole", userRole);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    // Result Set 1
                    while (await reader.ReadAsync())
                    {
                        response.ParentCorporates.Add(new ParentCorporateDto
                        {
                            ParentCorporateId = reader.GetInt32(reader.GetOrdinal("Parent_Corporate_Id")),
                            CorporateName = reader.IsDBNull(reader.GetOrdinal("Parent_Corporate_Name")) ? null : reader.GetString(reader.GetOrdinal("Parent_Corporate_Name")),
                            Zone = reader.IsDBNull(reader.GetOrdinal("Parent_Corporate_Zone")) ? null : reader.GetString(reader.GetOrdinal("Parent_Corporate_Zone")),
                            StateName = reader.IsDBNull(reader.GetOrdinal("StateName")) ? null : reader.GetString(reader.GetOrdinal("StateName")),
                            CityName = reader.IsDBNull(reader.GetOrdinal("CityName")) ? null : reader.GetString(reader.GetOrdinal("CityName")),
                            Address = reader.IsDBNull(reader.GetOrdinal("Parent_Corporate_Address")) ? null : reader.GetString(reader.GetOrdinal("Parent_Corporate_Address")),
                            CityId = reader.IsDBNull(reader.GetOrdinal("City_id")) ? 0 : reader.GetInt32(reader.GetOrdinal("City_id")),
                            StateId = reader.IsDBNull(reader.GetOrdinal("State_Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("State_Id")),
                            Pincode = reader.IsDBNull(reader.GetOrdinal("Parent_Corporate_Pincode")) ? null : reader.GetString(reader.GetOrdinal("Parent_Corporate_Pincode")),
                            ContactNo = reader.IsDBNull(reader.GetOrdinal("Parent_Corporate_CotactNo")) ? null : reader.GetString(reader.GetOrdinal("Parent_Corporate_CotactNo")),
                            Website = reader.IsDBNull(reader.GetOrdinal("Parent_Corporate_WebSite")) ? null : reader.GetString(reader.GetOrdinal("Parent_Corporate_WebSite")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Parent_Corporate_Email")) ? null : reader.GetString(reader.GetOrdinal("Parent_Corporate_Email")),
                            ActiveFlag = !reader.IsDBNull(reader.GetOrdinal("Active_Flag")) && reader.GetBoolean(reader.GetOrdinal("Active_Flag")),
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("Created_date")) ? null : reader.GetDateTime(reader.GetOrdinal("Created_date")),
                            CreatedBy = reader.IsDBNull(reader.GetOrdinal("Created_By")) ? null : reader.GetString(reader.GetOrdinal("Created_By")),
                            ModifiedDate = reader.IsDBNull(reader.GetOrdinal("Modifed_date")) ? null : reader.GetDateTime(reader.GetOrdinal("Modifed_date")),
                            ModifiedBy = reader.IsDBNull(reader.GetOrdinal("Modifed_By")) ? null : reader.GetString(reader.GetOrdinal("Modifed_By"))
                        });
                    }

                    // Result Set 2: Case Details
                    if (await reader.NextResultAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.CaseDetails.Add(new ParentCorporateDetailsDto
                            {
                                ParentCorporateId = reader.GetInt32(reader.GetOrdinal("Parent_Corporate_Id")),
                                ColumnName = reader.IsDBNull(reader.GetOrdinal("Column_Name")) ? null : reader.GetString(reader.GetOrdinal("Column_Name")),
                                ColumnDetails = reader.IsDBNull(reader.GetOrdinal("Column_Details")) ? null : reader.GetString(reader.GetOrdinal("Column_Details")),
                                ColumnName1 = reader.IsDBNull(reader.GetOrdinal("Column_Name1")) ? null : reader.GetString(reader.GetOrdinal("Column_Name1")),
                                ColumnDetails1 = reader.IsDBNull(reader.GetOrdinal("Column_Details1")) ? null : reader.GetString(reader.GetOrdinal("Column_Details1"))
                            });
                        }
                    }
                }
            }

            return response;
        }

        public async Task<SaveParentCorporateResponse> SaveParentCorporateAsync(SaveParentCorporateCommand request)
        {
            var response = new SaveParentCorporateResponse
            {
                ParentCorporateList = new List<ParentCorporateDto>(),
                CaseDetails = new List<ParentCorporateDetailsDto>()
            };

            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("SaveParentCorporate", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Corporate_Name", request.CorporateName);
                cmd.Parameters.AddWithValue("@Address", request.CorporateAddress);
                cmd.Parameters.AddWithValue("@State_id", request.StateId);
                cmd.Parameters.AddWithValue("@City_id", request.CityId);
                cmd.Parameters.AddWithValue("@Pincode", request.Pincode);
                cmd.Parameters.AddWithValue("@contact_no", request.ContactNo);
                cmd.Parameters.AddWithValue("@Zone", request.ZoneId);
                cmd.Parameters.AddWithValue("@WebSite", request.Website);
                cmd.Parameters.AddWithValue("@Email_id", request.Email);
                cmd.Parameters.AddWithValue("@User_id", request.UserId);
                cmd.Parameters.AddWithValue("@UserType", request.UserType);
                cmd.Parameters.AddWithValue("@UserRole", request.UserRole);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    // ResultSet 1: Message
                    if (await reader.ReadAsync())
                    {
                        response.Message = reader.IsDBNull(0) ? "" : reader.GetString(0);
                    }

                    // ResultSet 2: ParentCorporateList
                    if (await reader.NextResultAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.ParentCorporateList.Add(new ParentCorporateDto
                            {
                                ParentCorporateId = reader.GetInt32(reader.GetOrdinal("Parent_Corporate_Id")),
                                CorporateName = reader.GetString(reader.GetOrdinal("Parent_Corporate_Name")),
                                Address = reader.IsDBNull(reader.GetOrdinal("Parent_Corporate_Address")) ? null : reader.GetString(reader.GetOrdinal("Parent_Corporate_Address"))
                                // Add other fields as needed
                            });
                        }
                    }

                    // ResultSet 3: CaseDetails
                    if (await reader.NextResultAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.CaseDetails.Add(new ParentCorporateDetailsDto
                            {
                                ParentCorporateId = reader.GetInt32(reader.GetOrdinal("Parent_Corporate_Id")),
                                ColumnName = reader.IsDBNull(reader.GetOrdinal("Column_Name")) ? null : reader.GetString(reader.GetOrdinal("Column_Name")),
                                ColumnDetails = reader.IsDBNull(reader.GetOrdinal("Column_Details")) ? null : reader.GetString(reader.GetOrdinal("Column_Details")),
                                ColumnName1 = reader.IsDBNull(reader.GetOrdinal("Column_Name1")) ? null : reader.GetString(reader.GetOrdinal("Column_Name1")),
                                ColumnDetails1 = reader.IsDBNull(reader.GetOrdinal("Column_Details1")) ? null : reader.GetString(reader.GetOrdinal("Column_Details1"))
                            });
                        }
                    }
                }
            }

            return response;
        }

        public async Task<FetchCorporateDetailsResponse> FetchCorporateDetailsAsync(FetchCorporateDetailsQuery request)
        {
            var response = new FetchCorporateDetailsResponse
            {
                ExtraDetails1 = new List<CorporateExtraDetailsDto>(),
                ExtraDetails2 = new List<CorporateExtraDetailsDto>()
            };

            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("FetchCorporateDetails", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", request.UserId);
                cmd.Parameters.AddWithValue("@UserType", request.UserType);
                cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
                cmd.Parameters.AddWithValue("@Parent_Corporate_id", request.ParentCorporateId);
                cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    // ResultSet 1: Corporate Details
                    if (await reader.ReadAsync())
                    {
                        response.CorporateDetails = new CorporateDetailsDto
                        {
                            CorporateId = reader.GetInt32(reader.GetOrdinal("Corporate_Id")),
                            ParentCorporateId = reader.GetInt32(reader.GetOrdinal("Parent_Corporate_Id")),
                            ParentCorporateName = reader.GetString(reader.GetOrdinal("Parent_Corporate_Name")),
                            CorporateName = reader.GetString(reader.GetOrdinal("Corporate_Name")),
                            CorporateType = reader.GetString(reader.GetOrdinal("Corporate_Type")),
                            CorporateAddress = reader.GetString(reader.GetOrdinal("Corporate_Address")),
                            CityId = reader.GetInt32(reader.GetOrdinal("City_id")),
                            StateId = reader.GetInt32(reader.GetOrdinal("State_Id")),
                            StateName = reader.GetString(reader.GetOrdinal("StateName")),
                            CityName = reader.GetString(reader.GetOrdinal("CityName")),
                            Pincode = reader.GetString(reader.GetOrdinal("Corporate_Pincode")),
                            ContactNo = reader.GetString(reader.GetOrdinal("Corporate_CotactNo")),
                            Zone = reader.GetString(reader.GetOrdinal("Corporate_Zone")),
                            Website = reader.GetString(reader.GetOrdinal("Corporate_WebSite")),
                            Email = reader.GetString(reader.GetOrdinal("Corporate_Email")),
                            ActiveFlag = !reader.IsDBNull(reader.GetOrdinal("Active_Flag")) && reader.GetBoolean(reader.GetOrdinal("Active_Flag")),
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("Created_date")) ? null : reader.GetDateTime(reader.GetOrdinal("Created_date")),
                            CreatedBy = reader.IsDBNull(reader.GetOrdinal("Created_By")) ? null : reader.GetString(reader.GetOrdinal("Created_By")),
                            ModifiedDate = reader.IsDBNull(reader.GetOrdinal("Modifed_date")) ? null : reader.GetDateTime(reader.GetOrdinal("Modifed_date")),
                            ModifiedBy = reader.IsDBNull(reader.GetOrdinal("Modifed_By")) ? null : reader.GetString(reader.GetOrdinal("Modifed_By"))
                        };
                    }

                    // ResultSet 2: ExtraDetails1
                    if (await reader.NextResultAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.ExtraDetails1.Add(new CorporateExtraDetailsDto
                            {
                                CorporateId = reader.GetInt32(reader.GetOrdinal("Corporate_Id")),
                                ColumnName = reader.IsDBNull(reader.GetOrdinal("Column_Name")) ? null : reader.GetString(reader.GetOrdinal("Column_Name")),
                                ColumnDetails = reader.IsDBNull(reader.GetOrdinal("Column_Details")) ? null : reader.GetString(reader.GetOrdinal("Column_Details")),
                                ColumnName1 = reader.IsDBNull(reader.GetOrdinal("Column_Name1")) ? null : reader.GetString(reader.GetOrdinal("Column_Name1")),
                                ColumnDetails1 = reader.IsDBNull(reader.GetOrdinal("Column_Details1")) ? null : reader.GetString(reader.GetOrdinal("Column_Details1"))
                            });
                        }
                    }

                    // ResultSet 3: ExtraDetails2
                    if (await reader.NextResultAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.ExtraDetails2.Add(new CorporateExtraDetailsDto
                            {
                                CorporateId = reader.GetInt32(reader.GetOrdinal("Corporate_Id")),
                                ColumnName = reader.IsDBNull(reader.GetOrdinal("Column_Name")) ? null : reader.GetString(reader.GetOrdinal("Column_Name")),
                                ColumnDetails = reader.IsDBNull(reader.GetOrdinal("Column_Details")) ? null : reader.GetString(reader.GetOrdinal("Column_Details")),
                                ColumnName1 = reader.IsDBNull(reader.GetOrdinal("Column_Name1")) ? null : reader.GetString(reader.GetOrdinal("Column_Name1")),
                                ColumnDetails1 = reader.IsDBNull(reader.GetOrdinal("Column_Details1")) ? null : reader.GetString(reader.GetOrdinal("Column_Details1"))
                            });
                        }
                    }
                }
            }

            return response;
        }

        public async Task<FetchCorporateResponse> FetchCorporateListAsync(FetchCorporateListQuery request)
        {
            var response = new FetchCorporateResponse
            {
                Corporates = new List<CorporateListMasterDto>(),
                CorporateExtras = new List<CorporateListDetailsDto>()
            };

            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("FetchCorporate", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", request.UserId);
                cmd.Parameters.AddWithValue("@UserType", request.UserType);
                cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
                cmd.Parameters.AddWithValue("@Parent_Corporate_id", request.ParentCorporateId);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    // ResultSet 1: Corporate Master
                    while (await reader.ReadAsync())
                    {
                        response.Corporates.Add(new CorporateListMasterDto
                        {
                            CorporateId = reader.GetInt32(reader.GetOrdinal("Corporate_Id")),
                            ParentCorporateId = reader.GetInt32(reader.GetOrdinal("Parent_Corporate_Id")),
                            ParentCorporateName = reader.GetString(reader.GetOrdinal("Parent_Corporate_Name")),
                            CorporateName = reader.GetString(reader.GetOrdinal("Corporate_Name")),
                            CorporateType = reader.GetString(reader.GetOrdinal("Corporate_Type")),
                            CorporateAddress = reader.GetString(reader.GetOrdinal("Corporate_Address")),
                            CityId = reader.GetInt32(reader.GetOrdinal("City_id")),
                            StateId = reader.GetInt32(reader.GetOrdinal("State_Id")),
                            StateName = reader.GetString(reader.GetOrdinal("StateName")),
                            CityName = reader.GetString(reader.GetOrdinal("CityName")),
                            Pincode = reader.GetString(reader.GetOrdinal("Corporate_Pincode")),
                            ContactNo = reader.GetString(reader.GetOrdinal("Corporate_CotactNo")),
                            Zone = reader.GetString(reader.GetOrdinal("Corporate_Zone")),
                            Website = reader.GetString(reader.GetOrdinal("Corporate_WebSite")),
                            Email = reader.GetString(reader.GetOrdinal("Corporate_Email")),
                            ActiveFlag = !reader.IsDBNull(reader.GetOrdinal("Active_Flag")) && reader.GetBoolean(reader.GetOrdinal("Active_Flag")),
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("Created_date")) ? null : reader.GetDateTime(reader.GetOrdinal("Created_date")),
                            CreatedBy = reader.IsDBNull(reader.GetOrdinal("Created_By")) ? null : reader.GetString(reader.GetOrdinal("Created_By")),
                            ModifiedDate = reader.IsDBNull(reader.GetOrdinal("Modifed_date")) ? null : reader.GetDateTime(reader.GetOrdinal("Modifed_date")),
                            ModifiedBy = reader.IsDBNull(reader.GetOrdinal("Modifed_By")) ? null : reader.GetString(reader.GetOrdinal("Modifed_By"))
                        });
                    }

                    // ResultSet 2: Corporate Extras
                    if (await reader.NextResultAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.CorporateExtras.Add(new CorporateListDetailsDto
                            {
                                CorporateId = reader.GetInt32(reader.GetOrdinal("Corporate_Id")),
                                ColumnName = reader.IsDBNull(reader.GetOrdinal("Column_Name")) ? null : reader.GetString(reader.GetOrdinal("Column_Name")),
                                ColumnDetails = reader.IsDBNull(reader.GetOrdinal("Column_Details")) ? null : reader.GetString(reader.GetOrdinal("Column_Details")),
                                ColumnName1 = reader.IsDBNull(reader.GetOrdinal("Column_Name1")) ? null : reader.GetString(reader.GetOrdinal("Column_Name1")),
                                ColumnDetails1 = reader.IsDBNull(reader.GetOrdinal("Column_Details1")) ? null : reader.GetString(reader.GetOrdinal("Column_Details1"))
                            });
                        }
                    }
                }
            }

            return response;
        }

        public async Task<List<CorporateUserDto>> FetchCorporateUsersAsync(FetchCorporateUsersQuery request)
        {
            var result = new List<CorporateUserDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("FetchCorporateUsers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", request.UserId);
                cmd.Parameters.AddWithValue("@UserType", request.UserType);
                cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
                cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result.Add(new CorporateUserDto
                        {
                            ContactPersonId = reader.GetInt32(reader.GetOrdinal("Contact_Person_id")),
                            CorporateId = reader.GetInt32(reader.GetOrdinal("Corporate_Id")),
                            Salutation = reader.IsDBNull(reader.GetOrdinal("Contact_Person_Salutation")) ? null : reader.GetString(reader.GetOrdinal("Contact_Person_Salutation")),
                            FirstName = reader.IsDBNull(reader.GetOrdinal("Contact_Person_FirstName")) ? null : reader.GetString(reader.GetOrdinal("Contact_Person_FirstName")),
                            MiddleName = reader.IsDBNull(reader.GetOrdinal("Contact_Person_MiddleName")) ? null : reader.GetString(reader.GetOrdinal("Contact_Person_MiddleName")),
                            LastName = reader.IsDBNull(reader.GetOrdinal("Contact_Person_LastName")) ? null : reader.GetString(reader.GetOrdinal("Contact_Person_LastName")),
                            Mobile = reader.IsDBNull(reader.GetOrdinal("Contact_Person_Mobile")) ? null : reader.GetString(reader.GetOrdinal("Contact_Person_Mobile")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Contact_Person_Email")) ? null : reader.GetString(reader.GetOrdinal("Contact_Person_Email")),
                            UserRole = reader.IsDBNull(reader.GetOrdinal("User_role")) ? null : reader.GetString(reader.GetOrdinal("User_role")),
                            ActiveFlag = !reader.IsDBNull(reader.GetOrdinal("Active_Flag")) ? null : reader.GetString(reader.GetOrdinal("Active_Flag")),
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("Created_date")) ? null : reader.GetString(reader.GetOrdinal("Created_date")),
                            CreatedBy = reader.IsDBNull(reader.GetOrdinal("Created_By")) ? null : reader.GetString(reader.GetOrdinal("Created_By"))
                        });
                    }
                }
            }

            return result;
        }

        public async Task<string> AddCorporateUserAsync(AddCorporateUserCommand request)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            string message = "";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("Insert_Corporate_users", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", request.UserId);
                cmd.Parameters.AddWithValue("@UserType", request.UserType);
                cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
                cmd.Parameters.AddWithValue("@Contact_Person_FirstName", request.FirstName);
                cmd.Parameters.AddWithValue("@Contact_Person_MiddleName", request.MiddleName);
                cmd.Parameters.AddWithValue("@Contact_Person_LastName", request.LastName);
                cmd.Parameters.AddWithValue("@Contact_Person_Mobile", request.MobileNo);
                cmd.Parameters.AddWithValue("@Contact_Person_Email", request.EmailId);
                cmd.Parameters.AddWithValue("@User_Role_id", request.UserRoleId);
                cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        message = reader.GetString(0);
                    }
                }
            }

            return message;
        }

        public async Task<string> ModifyCorporateUserAsync(ModifyCorporateUserCommand request)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            string message = "";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("Update_Corporate_Users", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", request.UserId);
                cmd.Parameters.AddWithValue("@UserType", request.UserType);
                cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
                cmd.Parameters.AddWithValue("@Contact_Person_FirstName", request.FirstName);
                cmd.Parameters.AddWithValue("@Contact_Person_MiddleName", request.MiddleName);
                cmd.Parameters.AddWithValue("@Contact_Person_LastName", request.LastName);
                cmd.Parameters.AddWithValue("@Contact_Person_Mobile", request.MobileNo);
                cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);
                cmd.Parameters.AddWithValue("@Contact_Person_id", request.ContactPersonId);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        message = reader.GetString(0);
                    }
                }
            }

            return message;
        }

        public async Task<string> DeactivateCorporateUserAsync(DeactivateCorporateUserCommand request)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            string message = "";

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("Deactivate_Corporate_Users", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", request.UserId);
                cmd.Parameters.AddWithValue("@UserType", request.UserType);
                cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
                cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);
                cmd.Parameters.AddWithValue("@Contact_Person_id", request.ContactPersonId);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        message = reader.GetString(0);
                    }
                }
            }

            return message;
        }

        public async Task<FetchCorporateInsurerResponse> FetchCorporateInsurersAsync(int corporateId, int userId, string userType, string userRole)
        {
            var result = new FetchCorporateInsurerResponse();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("FetchCorporateInsurer", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@UserType", userType);
            cmd.Parameters.AddWithValue("@UserRole", userRole);
            cmd.Parameters.AddWithValue("@Corporate_id", corporateId);

            await conn.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.CorporateInsurers.Add(new CorporateInsurerDto
                {
                    CorporateInsurerId = reader.GetInt32(reader.GetOrdinal("Corporate_Insurer_id")),
                    CorporateId = reader.GetInt32(reader.GetOrdinal("Corporate_Id")),
                    InsurerName = reader["Insurer_Name"]?.ToString(),
                    EmpanneledDate = DateTime.TryParse(reader["Empanneled_date"]?.ToString(), out var empDate) ? empDate : (DateTime?)null,
                    PortalLink = reader["Portal_Link"]?.ToString(),
                    PortalUserId = reader["Portal_UserId"]?.ToString(),
                    PortalPassword = reader["Portal_Password"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = DateTime.TryParse(reader["Created_date"]?.ToString(), out var createdDate) ? createdDate : (DateTime?)null,
                    CreatedBy = reader["Created_By"]?.ToString(),
                    ModifiedDate = DateTime.TryParse(reader["Modifed_date"]?.ToString(), out var modDate) ? modDate : (DateTime?)null,
                    ModifiedBy = reader["Modifed_By"]?.ToString()
                });
            }

            if (await reader.NextResultAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.InsurerMasterList.Add(new InsurerMasterDto
                    {
                        InsurerId = reader.GetInt32(reader.GetOrdinal("Insurer_id")),
                        InsurerName = reader["Insurer_Name"]?.ToString(),
                        InsurerCode = reader["Insurer_Code"]?.ToString(),
                        ActiveFlag = reader["Active_Flag"]?.ToString(),
                        CreatedDate = DateTime.TryParse(reader["Created_date"]?.ToString(), out var createdDate) ? createdDate : (DateTime?)null,
                        CreatedBy = reader["Created_By"]?.ToString(),
                        ModifiedDate = DateTime.TryParse(reader["Modifed_date"]?.ToString(), out var modDate) ? modDate : (DateTime?)null,
                        ModifiedBy = reader["Modifed_By"]?.ToString()
                    });
                }
            }

            return result;
        }
        public async Task<List<CorporateInsurerRateDto>> FetchCorporateInsurerRatesAsync(int corporateInsurerId, int corporateId, int userId, string userType, string userRole)
        {
            var result = new List<CorporateInsurerRateDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("FetchCorporateInsurer_Rates", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@UserType", userType);
                cmd.Parameters.AddWithValue("@UserRole", userRole);
                cmd.Parameters.AddWithValue("@Corporate_Insurer_id", corporateInsurerId);
                cmd.Parameters.AddWithValue("@Corporate_id", corporateId);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result.Add(new CorporateInsurerRateDto
                        {
                            CorporateInsurerRatesId = reader.GetInt32(reader.GetOrdinal("Corporate_Insurer_Rates_id")),
                            CorporateInsurerId = reader.GetInt32(reader.GetOrdinal("Corporate_Insurer_id")),
                            RateListDocument = reader["Rate_List_document"]?.ToString(),
                            RateRemarks = reader["Rate_remarks"]?.ToString(),
                            ActiveFlag = reader["Active_Flag"]?.ToString(),

                            RateActiveFromDate = DateTime.TryParse(reader["Rate_Active_from_date"]?.ToString(), out var fromDate)
                                ? fromDate : (DateTime?)null,

                            RateActiveToDate = DateTime.TryParse(reader["Rate_Active_to_date"]?.ToString(), out var toDate)
                                ? toDate : (DateTime?)null,

                            CreatedDate = DateTime.TryParse(reader["Created_date"]?.ToString(), out var createdDate)
                                ? createdDate : (DateTime?)null,

                            ModifiedDate = DateTime.TryParse(reader["Modifed_date"]?.ToString(), out var modifiedDate)
                                ? modifiedDate : (DateTime?)null,
                            ModifiedBy = reader["Modifed_By"]?.ToString(),
                            CreatedBy = reader["Created_By"]?.ToString()
                        });
                    }
                }
            }

            return result;
        }

        public async Task<string> DeactivateCorporateInsurerAsync(int corporateInsurerId, int corporateId, int userId, string userType, string userRole)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("Deactivate_Corporate_Insurer", conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@UserType", userType);
            cmd.Parameters.AddWithValue("@UserRole", userRole);
            cmd.Parameters.AddWithValue("@Corporate_id", corporateId);
            cmd.Parameters.AddWithValue("@Corporate_Insurer_id", corporateInsurerId);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return result?.ToString() ?? "No response";
        }
        public async Task<string> AddCorporateInsurerAsync(AddCorporateInsurerCommand command)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("Insert_Corporate_Insurer", conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@UserId", command.UserId);
            cmd.Parameters.AddWithValue("@UserType", command.UserType);
            cmd.Parameters.AddWithValue("@UserRole", command.UserRole);
            cmd.Parameters.AddWithValue("@Insurer_id", command.InsurerId);
            cmd.Parameters.AddWithValue("@Empanneled_date", command.EmpanneledDate);
            cmd.Parameters.AddWithValue("@Portal_Link", command.PortalLink);
            cmd.Parameters.AddWithValue("@Portal_UserId", command.PortalUserId);
            cmd.Parameters.AddWithValue("@Portal_Password", command.PortalPassword);
            cmd.Parameters.AddWithValue("@Corporate_id", command.CorporateId);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return result?.ToString() ?? "No response";
        }
        public async Task<string> ModifyCorporateInsurerAsync(ModifyCorporateInsurerCommand command)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("Update_Corporate_Insurer", conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@UserId", command.UserId);
            cmd.Parameters.AddWithValue("@UserType", command.UserType);
            cmd.Parameters.AddWithValue("@UserRole", command.UserRole);
            cmd.Parameters.AddWithValue("@Insurer_id", command.CorporateInsurerId);
            cmd.Parameters.AddWithValue("@Empanneled_date", command.EmpanneledDate);
            cmd.Parameters.AddWithValue("@Portal_Link", command.PortalLink);
            cmd.Parameters.AddWithValue("@Portal_UserId", command.PortalUserId);
            cmd.Parameters.AddWithValue("@Portal_Password", command.PortalPassword);
            cmd.Parameters.AddWithValue("@Corporate_id", command.CorporateId);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return result?.ToString() ?? "No response";
        }
        public async Task<string> AddCorporateInsurerRateAsync(AddCorporateInsurerRateCommand command)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("Insert_Corporate_Insurer_Rates", conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@UserId", command.UserId);
            cmd.Parameters.AddWithValue("@UserType", command.UserType);
            cmd.Parameters.AddWithValue("@UserRole", command.UserRole);
            cmd.Parameters.AddWithValue("@Corporate_Insurer_id", command.CorporateInsurerId);
            cmd.Parameters.AddWithValue("@Corporate_id", command.CorporateId);
            cmd.Parameters.AddWithValue("@Rate_Active_from_date", command.FromDate);
            cmd.Parameters.AddWithValue("@Rate_Active_to_date", command.ToDate);
            cmd.Parameters.AddWithValue("@Rate_List_document", command.RateListDocument);
            cmd.Parameters.AddWithValue("@Rate_remarks", command.RateRemarks);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            return result?.ToString() ?? "Insert failed";
        }

        public async Task<List<CorporateMouDto>> FetchCorporateMOUAsync(int corporateId, int userId, string userType, string userRole)
        {
            var response = new List<CorporateMouDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("FetchCorporate_MOU", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@UserType", userType);
            cmd.Parameters.AddWithValue("@UserRole", userRole);
            cmd.Parameters.AddWithValue("@Corporate_id", corporateId);

            await conn.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                response.Add(new CorporateMouDto
                {
                    Tbl_Id = reader.GetInt32(reader.GetOrdinal("tbl_id")),
                    CorporateMOUId = reader.GetInt32(reader.GetOrdinal("Corporate_MOU_id")),
                    CorporateId = reader.GetInt32(reader.GetOrdinal("Corporate_id")),
                    ActiveFromDate = DateTime.TryParse(reader["MOU_Active_from_date"]?.ToString(), out var fromDate)
                                ? fromDate : (DateTime?)null,
                    ActiveToDate = DateTime.TryParse(reader["MOU_Active_to_date"]?.ToString(), out var toDate)
                                ? toDate : (DateTime?)null,
                    DocumentName = reader["MOU_document_Name"]?.ToString(),
                    DocumentLink = reader["MOU_document_Link"]?.ToString(),
                    Remarks = reader["MOU_document_Remarks"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = DateTime.TryParse(reader["Created_date"]?.ToString(), out var createdDate)
                                ? createdDate : (DateTime?)null,
                    CreatedBy = reader["Created_By"]?.ToString(),
                    ModifiedDate = DateTime.TryParse(reader["Modifed_date"]?.ToString(), out var modifiedDate)
                                ? modifiedDate : (DateTime?)null,
                    ModifiedBy = reader["Modifed_By"]?.ToString()
                });
            }

            return response;
        }
        public async Task<FetchCorporateRenewalsResponse> FetchCorporateRenewalsAsync(int corporateId, int userId, string userType, string userRole)
        {
            var response = new FetchCorporateRenewalsResponse();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("FetchCorporateRenewals", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@UserType", userType);
            cmd.Parameters.AddWithValue("@UserRole", userRole);
            cmd.Parameters.AddWithValue("@Corporate_id", corporateId);

            await conn.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();

            // First ResultSet - Renewals
            while (await reader.ReadAsync())
            {
                response.Renewals.Add(new CorporateRenewalDto
                {
                    CorporateServiceRenewalId = reader.GetInt32(reader.GetOrdinal("Corporate_Service_Renewal_id")),
                    CorporateId = reader.GetInt32(reader.GetOrdinal("Corporate_Id")),
                    ServiceRenewalName = reader["Service_Renewal_Name"]?.ToString(),
                    ServiceDesc = reader["Service_Desc"]?.ToString(),
                    RenewalDate = DateTime.TryParse(reader["Renewal_date"]?.ToString(), out var renewalDate)
            ? renewalDate : (DateTime?)null,
                    ExpireDate = DateTime.TryParse(reader["Expire_date"]?.ToString(), out var expireDate)
            ? expireDate : (DateTime?)null,
                    RenewalFlag = reader["Renewal_Flag"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = DateTime.TryParse(reader["Created_date"]?.ToString(), out var createdDate)
            ? createdDate : (DateTime?)null,
                    CreatedBy = reader["Created_By"]?.ToString(),
                    ModifiedDate = DateTime.TryParse(reader["Modifed_date"]?.ToString(), out var modifiedDate)
            ? modifiedDate : (DateTime?)null,
                    ModifiedBy = reader["Modifed_By"]?.ToString() 
                });
            }

            if (await reader.NextResultAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.RenewalDetails.Add(new CorporateRenewalDetailsDto
                    {
                        Service_Renewal_id = reader.GetInt32(reader.GetOrdinal("Service_Renewal_id")),
                        Service_Renewal_Name = reader["Service_Renewal_Name"]?.ToString(),
                        Service_Renewal_Desc = reader["Service_Renewal_Desc"]?.ToString(),
                        Active_Flag = reader["Active_Flag"]?.ToString(),
                        Created_date = DateTime.TryParse(reader["Created_date"]?.ToString(), out var createdDate) ? createdDate : (DateTime?)null,
                        Created_By = reader["Created_By"]?.ToString(),
                        Modifed_date = DateTime.TryParse(reader["Modifed_date"]?.ToString(), out var modifiedDate) ? modifiedDate : (DateTime?)null,
                        Modifed_By = reader["Modifed_By"]?.ToString()
                    });
                }
            }

            return response;
        }

        public async Task<string> AddCorporateRenewalAsync(AddCorporateRenewalCommand request)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("Insert_Corporate_Service_Renewals", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", request.UserId);
            cmd.Parameters.AddWithValue("@UserType", request.UserType);
            cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
            cmd.Parameters.AddWithValue("@Service_Renewal_id", request.ServiceRenewalId);
            cmd.Parameters.AddWithValue("@Service_Desc", request.ServiceDesc);
            cmd.Parameters.AddWithValue("@Renewal_date", request.RenewalDate);
            cmd.Parameters.AddWithValue("@Expire_date", request.ExpireDate);
            cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync(); // Use ExecuteNonQueryAsync if SP doesn't return scalar
            return result?.ToString() ?? "Success";
        }

        public async Task<FetchCorporateTPAResponse> FetchCorporateTPAAsync(FetchCorporateTPAQuery request)
        {
            var result = new FetchCorporateTPAResponse();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("FetchCorporateTPA", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", request.UserId);
            cmd.Parameters.AddWithValue("@UserType", request.UserType);
            cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
            cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.CorporateTPAs.Add(new CorporateTPADetailsDto
                {
                    CorporateTPAId = reader.GetInt32(reader.GetOrdinal("Corporate_TPA_id")),
                    CorporateId = reader.GetInt32(reader.GetOrdinal("Corporate_Id")),
                    TPAName = reader["TPA_Name"]?.ToString(),
                    EmpanneledDate = DateTime.TryParse(reader["Empanneled_date"]?.ToString(), out var empDate) ? empDate : (DateTime?)null,
                    PortalLink = reader["Portal_Link"]?.ToString(),
                    PortalUserId = reader["Portal_UserId"]?.ToString(),
                    PortalPassword = reader["Portal_Password"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = DateTime.TryParse(reader["Created_date"]?.ToString(), out var created) ? created : (DateTime?)null,
                    CreatedBy = reader["Created_By"]?.ToString(),
                    ModifiedDate = DateTime.TryParse(reader["Modifed_date"]?.ToString(), out var mod) ? mod : (DateTime?)null,
                    ModifiedBy = reader["Modifed_By"]?.ToString()
                });
            }

            if (await reader.NextResultAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.TPAMasterList.Add(new TPAMasterDto
                    {
                        TPAId = reader.GetInt32(reader.GetOrdinal("TPA_Id")),
                        TPName = reader["TP_Name"]?.ToString(),
                        LicenseNumber = reader["License_Number"]?.ToString(),
                        LicenseValidity = DateTime.TryParse(reader["License_Validity"]?.ToString(), out var licVal) ? licVal : (DateTime?)null,
                        ChiefExecutiveOfficer = reader["Chief_Executive_Officer"]?.ToString(),
                        TPAAddress = reader["TPA_Address"]?.ToString(),
                        SeniorCitizenHelpline = reader["Senior_Citizen_Helpline"]?.ToString(),
                        TollFreeNumber = reader["Toll_Free_Number"]?.ToString(),
                        TPAEmail = reader["TPA_Email"]?.ToString(),
                        TPAWebsite = reader["TPA_Website"]?.ToString(),
                        ActiveFlag = reader["Active_Flag"]?.ToString(),
                        CreatedDate = DateTime.TryParse(reader["Created_date"]?.ToString(), out var created) ? created : (DateTime?)null,
                        CreatedBy = reader["Created_By"]?.ToString(),
                        ModifiedDate = DateTime.TryParse(reader["Modifed_date"]?.ToString(), out var mod) ? mod : (DateTime?)null,
                        ModifiedBy = reader["Modifed_By"]?.ToString()
                    });
                }
            }

            return result;
        }
        public async Task<List<CorporateTPARateDto>> FetchCorporateTPARatesAsync(FetchCorporateTPARatesQuery request)
        {
            var rates = new List<CorporateTPARateDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("FetchCorporateTPA_Rates", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", request.UserId);
            cmd.Parameters.AddWithValue("@UserType", request.UserType);
            cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
            cmd.Parameters.AddWithValue("@Corporate_TPA_id", request.CorporateTPAId);
            cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                rates.Add(new CorporateTPARateDto
                {
                    CorporateTPARatesId = reader.GetInt32(reader.GetOrdinal("Corporate_TPA_Rates_id")),
                    CorporateTPAId = reader.GetInt32(reader.GetOrdinal("Corporate_TPA_id")),
                    RateActiveFromDate = DateTime.TryParse(reader["Rate_Active_from_date"]?.ToString(), out var from) ? from : (DateTime?)null,
                    RateActiveToDate = DateTime.TryParse(reader["Rate_Active_to_date"]?.ToString(), out var to) ? to : (DateTime?)null,
                    RateListDocument = reader["Rate_List_document"]?.ToString(),
                    RateRemarks = reader["Rate_remarks"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = DateTime.TryParse(reader["Created_date"]?.ToString(), out var created) ? created : (DateTime?)null,
                    CreatedBy = reader["Created_By"]?.ToString(),
                    ModifiedDate = DateTime.TryParse(reader["Modifed_date"]?.ToString(), out var modified) ? modified : (DateTime?)null,
                    ModifiedBy = reader["Modifed_By"]?.ToString()
                });
            }

            return rates;
        }

        public async Task<string> AddCorporateTPAAsync(AddCorporateTPACommand request)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("Insert_Corporate_TPA", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", request.UserId);
            cmd.Parameters.AddWithValue("@UserType", request.UserType);
            cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
            cmd.Parameters.AddWithValue("@TPA_id", request.TPAId);
            cmd.Parameters.AddWithValue("@Empanneled_date", request.EmpanneledDate);
            cmd.Parameters.AddWithValue("@Portal_Link", request.PortalLink);
            cmd.Parameters.AddWithValue("@Portal_UserId", request.PortalUserId);
            cmd.Parameters.AddWithValue("@Portal_Password", request.PortalPassword);
            cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return "Corporate TPA added successfully.";
        }

        public async Task<string> ModifyCorporateTPAAsync(ModifyCorporateTPACommand request)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("Update_Corporate_TPA", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", request.UserId);
            cmd.Parameters.AddWithValue("@UserType", request.UserType);
            cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
            cmd.Parameters.AddWithValue("@Empanneled_date", request.EmpanneledDate);
            cmd.Parameters.AddWithValue("@Portal_Link", request.PortalLink);
            cmd.Parameters.AddWithValue("@Portal_UserId", request.PortalUserId);
            cmd.Parameters.AddWithValue("@Portal_Password", request.PortalPassword);
            cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);
            cmd.Parameters.AddWithValue("@Corporate_TPA_id", request.CorporateTPAId);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return "Corporate TPA modified successfully.";
        }

        public async Task<string> DeactivateCorporateTPAAsync(DeactivateCorporateTPACommand request)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("Deactivate_Corporate_TPA", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", request.UserId);
            cmd.Parameters.AddWithValue("@UserType", request.UserType);
            cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
            cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);
            cmd.Parameters.AddWithValue("@Corporate_TPA_id", request.CorporateTPAId);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return "Corporate TPA deactivated successfully.";
        }

        public async Task<string> InsertCorporateTPARatesAsync(InsertCorporateTPARatesCommand request)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("Insert_Corporate_TPA_Rates", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserId", request.UserId);
            cmd.Parameters.AddWithValue("@UserType", request.UserType);
            cmd.Parameters.AddWithValue("@UserRole", request.UserRole);
            cmd.Parameters.AddWithValue("@Corporate_TPA_id", request.CorporateTPAId);
            cmd.Parameters.AddWithValue("@Corporate_id", request.CorporateId);
            cmd.Parameters.AddWithValue("@Rate_Active_from_date", request.RateFromDate);
            cmd.Parameters.AddWithValue("@Rate_Active_to_date", request.RateToDate);
            cmd.Parameters.AddWithValue("@Rate_List_document", request.DocumentLink);
            cmd.Parameters.AddWithValue("@Rate_remarks", request.RateRemarks);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return "Corporate TPA rates added successfully.";
        }

    }
}
