using Vertroue.HMS.API.Application.Features.MasterData.Models;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Microsoft.Data.SqlClient;
using System.Data;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateType.Model;
using Microsoft.Extensions.Configuration;
using Vertroue.HMS.API.Application.Features.MasterData.AdmissionType.Model;
using Vertroue.HMS.API.Application.Features.MasterData.Cities.Models;
using Vertroue.HMS.API.Application.Features.MasterData.CorporatePlan.Model;
using Vertroue.HMS.API.Application.Features.MasterData.CorporateServiceRenewal.Model;
using Vertroue.HMS.API.Application.Features.MasterData.DocumentType.Model;
using Vertroue.HMS.API.Application.Features.MasterData.GenderMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.IdentificationTypeMaster.Model;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    internal class MasterDataRepository : IMasterDataRepository
    {
        private readonly IConfiguration _config;

        public MasterDataRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<StateDto>> GetStatesAsync() => new List<StateDto> {
        new StateDto { StateId = 1, StateName = "Maharashtra" },
        new StateDto { StateId = 2, StateName = "Gujarat" }
    };

        public async Task<List<ZoneDto>> GetZonesAsync() => new List<ZoneDto> {
        new ZoneDto { ZoneId = 1, ZoneName = "West Zone" },
        new ZoneDto { ZoneId = 2, ZoneName = "North Zone" }
    };

        public async Task<List<CityDto>> GetCitiesAsync(int stateId)
        {
            var cities = new List<CityDto> {
            new CityDto { CityId = 1, CityName = "Mumbai", StateId = 1 },
            new CityDto { CityId = 2, CityName = "Pune", StateId = 1 },
            new CityDto { CityId = 3, CityName = "Ahmedabad", StateId = 2 }
        };

            return cities.Where(c => c.StateId == stateId).ToList();
        }

        public async Task<string> ManageCorporateTypeAsync(object command, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Corporate_Type_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = command;
            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
            {
                cmd.Parameters.AddWithValue("@Corporate_Type_Name", data.CorporateTypeName);
                cmd.Parameters.AddWithValue("@Corporate_Type_Description", data.CorporateTypeDescription);
            }

            if (action != 'I')
                cmd.Parameters.AddWithValue("@Corporate_Type_Id", data.CorporateTypeId);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            string result = "";
            while (await reader.ReadAsync())
            {
                result = reader["msg"]?.ToString();
            }
            return result;
        }

        public async Task<List<CorporateTypeMasterDto>> FetchCorporateTypeAsync()
        {
            var result = new List<CorporateTypeMasterDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Corporate_Type_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new CorporateTypeMasterDto
                {
                    CorporateTypeId = Convert.ToInt32(reader["Corporate_Type_Id"]),
                    CorporateTypeName = reader["Corporate_Type_Name"]?.ToString(),
                    CorporateTypeDescription = reader["Corporate_Type_Description"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }
            return result;
        }

        public async Task<string> ManageAdmissionTypeAsync(object command, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Admission_Type_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = command;

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
                cmd.Parameters.AddWithValue("@Admission_Type_Name", data.AdmissionTypeName);

            if (action != 'I')
                cmd.Parameters.AddWithValue("@Admission_Type_Id", data.AdmissionTypeId);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            string result = "";
            while (await reader.ReadAsync())
            {
                result = reader["msg"]?.ToString();
            }

            return result;
        }

        public async Task<List<AdmissionTypeMasterDto>> FetchAdmissionTypeAsync()
        {
            var result = new List<AdmissionTypeMasterDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Admission_Type_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new AdmissionTypeMasterDto
                {
                    AdmissionTypeId = Convert.ToInt32(reader["Admission_Type_Id"]),
                    AdmissionTypeName = reader["Admission_Type_Name"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> ManageCityAsync(object command, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_City_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = command;

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
            {
                cmd.Parameters.AddWithValue("@City_Name", data.CityName);
                cmd.Parameters.AddWithValue("@State_Id", data.StateId);
            }

            if (action != 'I')
                cmd.Parameters.AddWithValue("@City_Id", data.CityId);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            string result = "";
            while (await reader.ReadAsync())
            {
                result = reader["msg"]?.ToString();
            }

            return result;
        }

        public async Task<List<CityMasterDto>> FetchCitiesAsync()
        {
            var response = new List<CityMasterDto>();

            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_City_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            // Read City list
            while (await reader.ReadAsync())
            {
                response.Add(new CityMasterDto
                {
                    CityId = Convert.ToInt32(reader["City_Id"]),
                    CityName = reader["City_Name"]?.ToString(),
                    StateId = Convert.ToInt32(reader["State_Id"]),
                    StateName = reader["State_name"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }           

            return response;
        }

        public async Task<string> ManageCorporatePlanAsync(object command, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Corporate_Plan_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = command;

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
            {
                cmd.Parameters.AddWithValue("@Corporate_Plan_Name", data.CorporatePlanName);
                cmd.Parameters.AddWithValue("@Corporate_Plan_Description", data.CorporatePlanDescription);
            }

            if (action != 'I')
            {
                cmd.Parameters.AddWithValue("@Corporate_Plan_Id", data.CorporatePlanId);
            }

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            string result = "";
            while (await reader.ReadAsync())
            {
                result = reader["msg"]?.ToString();
            }

            return result;
        }

        public async Task<List<CorporatePlanDto>> FetchCorporatePlansAsync()
        {
            var result = new List<CorporatePlanDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Corporate_Plan_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new CorporatePlanDto
                {
                    CorporatePlanId = Convert.ToInt32(reader["Corporate_Plan_Id"]),
                    CorporatePlanName = reader["Corporate_Plan_Name"]?.ToString(),
                    CorporatePlanDescription = reader["Corporate_Plan_Description"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> ManageServiceRenewalAsync(int? id, string name, string desc, int userId, string action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Corporate_Service_Renewal_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", userId);

            if (action == "I" || action == "U")
            {
                cmd.Parameters.AddWithValue("@Service_Renewal_Name", name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Service_Renewal_Desc", desc ?? (object)DBNull.Value);
            }

            if (action != "I")
            {
                cmd.Parameters.AddWithValue("@Service_Renewal_id", id ?? (object)DBNull.Value);
            }

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            string result = "";
            while (await reader.ReadAsync())
            {
                result = reader["msg"]?.ToString();
            }

            return result;
        }
        public async Task<List<CorporateServiceRenewalDto>> FetchServiceRenewalsAsync()
        {
            var result = new List<CorporateServiceRenewalDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Corporate_Service_Renewal_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", "S");
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new CorporateServiceRenewalDto
                {
                    ServiceRenewalId = Convert.ToInt32(reader["Service_Renewal_id"]),
                    ServiceRenewalName = reader["Service_Renewal_Name"]?.ToString(),
                    ServiceRenewalDesc = reader["Service_Renewal_Desc"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> ManageDocumentTypeAsync(int? id, string name, string desc, string owner, int userId, string action)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("CRUD_Document_Type_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", userId);
            if (action != "I")
                cmd.Parameters.AddWithValue("@Document_Type_id", id ?? (object)DBNull.Value);
            if (action == "I" || action == "U")
            {
                cmd.Parameters.AddWithValue("@Document_Type_Name", name ?? "");
                cmd.Parameters.AddWithValue("@Document_desc", desc ?? "");
                cmd.Parameters.AddWithValue("@Document_Owner", owner ?? "");
            }

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            return await reader.ReadAsync() ? reader["msg"]?.ToString() : "";
        }

        public async Task<List<DocumentTypeDto>> FetchDocumentTypesAsync()
        {
            var result = new List<DocumentTypeDto>();
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("CRUD_Document_Type_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", "S");
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new DocumentTypeDto
                {
                    DocumentTypeId = Convert.ToInt32(reader["Document_Type_id"]),
                    DocumentTypeName = reader["Document_Type_Name"]?.ToString(),
                    DocumentDesc = reader["Document_desc"]?.ToString(),
                    DocumentOwner = reader["Document_Owner"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> ManageGenderAsync(object command, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Gender_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = command;

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
                cmd.Parameters.AddWithValue("@Gender_Name", data.GenderName);

            if (action != 'I')
                cmd.Parameters.AddWithValue("@Gender_id", data.GenderId);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            string result = "";
            while (await reader.ReadAsync())
            {
                result = reader["msg"]?.ToString();
            }

            return result;
        }

        public async Task<List<GenderDto>> FetchGendersAsync()
        {
            var result = new List<GenderDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Gender_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new GenderDto
                {
                    GenderId = Convert.ToInt32(reader["Gender_id"]),
                    GenderName = reader["Gender_Name"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }
        public async Task<string> ManageIdentificationTypeAsync(object command, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Identification_Type_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = command;
            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
            {
                cmd.Parameters.AddWithValue("@Identification_Type_Name", data.IdentificationTypeName);
                cmd.Parameters.AddWithValue("@Identification_Type_desc", data.IdentificationTypeDescription);
            }

            if (action != 'I')
                cmd.Parameters.AddWithValue("@Identification_Type_id", data.IdentificationTypeId);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            string result = "";
            while (await reader.ReadAsync())
                result = reader["msg"]?.ToString();

            return result;
        }

        public async Task<List<IdentificationTypeDto>> FetchIdentificationTypesAsync()
        {
            var result = new List<IdentificationTypeDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Identification_Type_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new IdentificationTypeDto
                {
                    IdentificationTypeId = Convert.ToInt32(reader["Identification_Type_id"]),
                    IdentificationTypeName = reader["Identification_Type_Name"]?.ToString(),
                    IdentificationTypeDescription = reader["Identification_Type_desc"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }
    }
}
