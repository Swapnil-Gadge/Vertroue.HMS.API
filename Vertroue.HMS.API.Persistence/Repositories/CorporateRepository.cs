using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Corporate.Details.Model;
using Vertroue.HMS.API.Application.Features.Corporate.Details.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Model;
using Vertroue.HMS.API.Application.Features.Corporate.HospitalUsers.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.List.Models;
using Vertroue.HMS.API.Application.Features.Corporate.List.Queries;
using Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Commands;
using Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Model;
using Vertroue.HMS.API.Application.Features.Corporate.Onboarding.Queries;

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
                            CreatedDate = reader.IsDBNull(reader.GetOrdinal("Created_date")) ? null: reader.GetString(reader.GetOrdinal("Created_date")),
                            CreatedBy = reader.IsDBNull(reader.GetOrdinal("Created_By")) ? null : reader.GetString(reader.GetOrdinal("Created_By"))
                        });
                    }
                }
            }

            return result;
        }
    }
}
