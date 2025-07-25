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
using Vertroue.HMS.API.Application.Features.MasterData.InsurerMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.RelationMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.States.Model;
using Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Commands.Add;
using Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Commands.Deactivate;
using Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Commands.Update;
using Vertroue.HMS.API.Application.Features.MasterData.StatusMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.StatusProcessFlow.Model;
using Vertroue.HMS.API.Application.Features.MasterData.TpaMaster.Model;
using Vertroue.HMS.API.Application.Features.MasterData.UserRole.Model;
using Vertroue.HMS.API.Application.Features.MasterData.UserType.Model;
using Vertroue.HMS.API.Application.Features.MasterData.Zones.Model;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    internal class MasterDataRepository : IMasterDataRepository
    {
        private readonly IConfiguration _config;

        public MasterDataRepository(IConfiguration config)
        {
            _config = config;
        }
    //    public async Task<List<StateDto>> GetStatesAsync() => new List<StateDto> {
    //    new StateDto { StateId = 1, StateName = "Maharashtra" },
    //    new StateDto { StateId = 2, StateName = "Gujarat" }
    //};

    //    public async Task<List<ZoneDto>> GetZonesAsync() => new List<ZoneDto> {
    //    new ZoneDto { ZoneId = 1, ZoneName = "West Zone" },
    //    new ZoneDto { ZoneId = 2, ZoneName = "North Zone" }
    //};

    //    public async Task<List<CityDto>> GetCitiesAsync(int stateId)
    //    {
    //        var cities = new List<CityDto> {
    //        new CityDto { CityId = 1, CityName = "Mumbai", StateId = 1 },
    //        new CityDto { CityId = 2, CityName = "Pune", StateId = 1 },
    //        new CityDto { CityId = 3, CityName = "Ahmedabad", StateId = 2 }
    //    };

    //        return cities.Where(c => c.StateId == stateId).ToList();
    //    }

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

        public async Task<string> ManageInsurerAsync(object command, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Insurer_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = command;

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
            {
                cmd.Parameters.AddWithValue("@Insurer_Name", data.InsurerName);
                cmd.Parameters.AddWithValue("@Insurer_Code", data.InsurerCode);
            }

            if (action != 'I')
                cmd.Parameters.AddWithValue("@Insurer_id", data.InsurerId);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            string result = "";
            while (await reader.ReadAsync())
            {
                result = reader["msg"]?.ToString();
            }

            return result;
        }

        public async Task<List<InsurerDto>> FetchInsurersAsync()
        {
            var result = new List<InsurerDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Insurer_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new InsurerDto
                {
                    InsurerId = Convert.ToInt32(reader["Insurer_id"]),
                    InsurerName = reader["Insurer_Name"]?.ToString(),
                    InsurerCode = reader["Insurer_Code"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> ManageRelationMasterAsync(dynamic data, char action)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("CRUD_Relation_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action != 'I') cmd.Parameters.AddWithValue("@Relation_id", data.RelationId);
            if (action != 'D')
            {
                cmd.Parameters.AddWithValue("@Relation_code", data.RelationCode);
                cmd.Parameters.AddWithValue("@Relation_Name", data.RelationName);
            }

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            return await reader.ReadAsync() ? reader["msg"]?.ToString() : "No result";
        }

        public async Task<List<RelationMasterDto>> FetchRelationMasterAsync()
        {
            var list = new List<RelationMasterDto>();
            using var conn = new SqlConnection(_config.GetConnectionString("CoreDbConnectionString"));
            using var cmd = new SqlCommand("CRUD_Relation_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new RelationMasterDto
                {
                    RelationId = Convert.ToInt32(reader["Relation_id"]),
                    RelationCode = reader["Relation_code"]?.ToString(),
                    RelationName = reader["Relation_Name"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }
            return list;
        }
        public async Task<string> ManageStateMasterAsync(object request, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_State_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = request;

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
            {
                cmd.Parameters.AddWithValue("@State_Name", data.StateName);
                cmd.Parameters.AddWithValue("@State_Zone", data.StateZone ?? (object)DBNull.Value);
            }

            if (action != 'I')
            {
                cmd.Parameters.AddWithValue("@State_Id", data.StateId);
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

        public async Task<List<StateDto>> FetchStatesAsync()
        {
            var result = new List<StateDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_State_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new StateDto
                {
                    StateId = Convert.ToInt32(reader["State_Id"]),
                    StateName = reader["State_Name"]?.ToString(),
                    StateZone = reader["State_Zone"]?.ToString(),
                    ZoneName = reader["zone_name"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> ManageStatusMasterAsync(object request, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Status_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = request;

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
            {
                cmd.Parameters.AddWithValue("@Status_Name", data.Status_Name);
                cmd.Parameters.AddWithValue("@Status_Desc", data.Status_Desc);
                cmd.Parameters.AddWithValue("@Status_Action_Owner", data.Status_Action_Owner ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Status_Post_Action_Owner", data.Status_Post_Action_Owner ?? (object)DBNull.Value);
            }

            if (action != 'I')
            {
                cmd.Parameters.AddWithValue("@Status_id", data.Status_Id);
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

        public async Task<List<StatusMasterDto>> FetchStatusMasterAsync(int userId)
        {
            var result = new List<StatusMasterDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Status_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Status_id", DBNull.Value);
            cmd.Parameters.AddWithValue("@Status_Name", DBNull.Value);
            cmd.Parameters.AddWithValue("@Status_Desc", DBNull.Value);
            cmd.Parameters.AddWithValue("@Status_Action_Owner", DBNull.Value);
            cmd.Parameters.AddWithValue("@Status_Post_Action_Owner", DBNull.Value);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new StatusMasterDto
                {
                    Status_Id = Convert.ToInt32(reader["Status_id"]),
                    Status_Name = reader["Status_Name"]?.ToString(),
                    Status_Desc = reader["Status_Desc"]?.ToString(),
                    Status_Action_Owner = reader["Status_Action_Owner"]?.ToString(),
                    Status_Post_Action_Owner = reader["Status_Post_Action_Owner"]?.ToString(),
                    Active_Flag = reader["Active_Flag"]?.ToString(),
                    Created_date = reader["Created_date"]?.ToString(),
                    Created_by = reader["Created_by"]?.ToString(),
                    Modifed_date = reader["Modifed_date"]?.ToString(),
                    Modified_by = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> ManageStatusProcessFlowAsync(object request, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Status_Process_Flow", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = request;

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
            {
                cmd.Parameters.AddWithValue("@Post_status_id", data.PostStatusId);
            }

            if (action == 'I')
            {
                cmd.Parameters.AddWithValue("@Status_Id", data.StatusId);
            }

            if (action != 'I')
            {
                cmd.Parameters.AddWithValue("@Status_Process_id", data.StatusProcessId);
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

        public async Task<List<StatusProcessFlowDto>> FetchStatusProcessFlowAsync()
        {
            var result = new List<StatusProcessFlowDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Status_Process_Flow", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new StatusProcessFlowDto
                {
                    StatusProcessId = Convert.ToInt32(reader["Status_Process_id"]),
                    StatusId = Convert.ToInt32(reader["Status_Id"]),
                    CurrentStatus = reader["current_status"]?.ToString(),
                    PostStatusId = Convert.ToInt32(reader["Post_status_id"]),
                    PostStatus = reader["Post_Status"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> ManageTpaMasterAsync(object request, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_TPA_Master", conn) { CommandType = CommandType.StoredProcedure };
            dynamic data = request;

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
            {
                cmd.Parameters.AddWithValue("@TP_Name", data.TP_Name);
                cmd.Parameters.AddWithValue("@License_Number", data.License_Number);
                cmd.Parameters.AddWithValue("@License_Validity", data.License_Validity ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Chief_Executive_Officer", data.Chief_Executive_Officer);
                cmd.Parameters.AddWithValue("@TPA_Address", data.TPA_Address);
                cmd.Parameters.AddWithValue("@Senior_Citizen_Helpline", data.Senior_Citizen_Helpline);
                cmd.Parameters.AddWithValue("@Toll_Free_Number", data.Toll_Free_Number);
                cmd.Parameters.AddWithValue("@TPA_Email", data.TPA_Email);
                cmd.Parameters.AddWithValue("@TPA_Website", data.TPA_Website);
            }

            if (action != 'I')
            {
                cmd.Parameters.AddWithValue("@TPA_Id", data.TPA_Id);
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

        public async Task<List<TpaMasterDto>> FetchTpaMasterAsync()
        {
            var result = new List<TpaMasterDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_TPA_Master", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new TpaMasterDto
                {
                    TPA_Id = Convert.ToInt32(reader["TPA_Id"]),
                    TP_Name = reader["TP_Name"]?.ToString(),
                    License_Number = reader["License_Number"]?.ToString(),
                    License_Validity = reader["License_Validity"]?.ToString(),
                    Chief_Executive_Officer = reader["Chief_Executive_Officer"]?.ToString(),
                    TPA_Address = reader["TPA_Address"]?.ToString(),
                    Senior_Citizen_Helpline = reader["Senior_Citizen_Helpline"]?.ToString(),
                    Toll_Free_Number = reader["Toll_Free_Number"]?.ToString(),
                    TPA_Email = reader["TPA_Email"]?.ToString(),
                    TPA_Website = reader["TPA_Website"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> ManageUserRoleMasterAsync(object request, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_User_Role_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = request;

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
            {
                cmd.Parameters.AddWithValue("@User_role_Name", data.UserRoleName);
            }

            if (action != 'I')
            {
                cmd.Parameters.AddWithValue("@User_Role_id", data.UserRoleId);
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

        public async Task<List<UserRoleDto>> FetchUserRoleMasterAsync()
        {
            var result = new List<UserRoleDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_User_Role_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new UserRoleDto
                {
                    UserRoleId = Convert.ToInt32(reader["User_Role_id"]),
                    UserRoleName = reader["User_role_Name"]?.ToString(),
                    ActiveFlag = reader["Active_Flag"]?.ToString(),
                    CreatedDate = reader["Created_date"]?.ToString(),
                    CreatedBy = reader["Created_by"]?.ToString(),
                    ModifiedDate = reader["Modifed_date"]?.ToString(),
                    ModifiedBy = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> ManageUserTypeAsync(object request, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_User_Type_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = request;

            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
            {
                cmd.Parameters.AddWithValue("@User_Type_Name", data.User_Type_Name);
                cmd.Parameters.AddWithValue("@User_Type_Desc", data.User_Type_Desc ?? (object)DBNull.Value);
            }

            if (action != 'I')
            {
                cmd.Parameters.AddWithValue("@User_Type_id", data.User_Type_id);
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

        public async Task<List<UserTypeDto>> FetchUserTypeAsync()
        {
            var result = new List<UserTypeDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_User_Type_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new UserTypeDto
                {
                    User_Type_id = Convert.ToInt32(reader["User_Type_id"]),
                    User_Type_Name = reader["User_Type_Name"]?.ToString(),
                    User_Type_Desc = reader["User_Type_Desc"]?.ToString(),
                    Active_Flag = reader["Active_Flag"]?.ToString(),
                    Created_date = reader["Created_date"]?.ToString(),
                    Created_by = reader["Created_by"]?.ToString(),
                    Modified_date = reader["Modifed_date"]?.ToString(),
                    Modified_by = reader["Modified_by"]?.ToString()
                });
            }

            return result;
        }

        public async Task<string> ManageZoneMasterAsync(object request, char action)
        {
            var connStr = _config.GetConnectionString("CoreDbConnectionString");
            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Zone_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            dynamic data = request;
            cmd.Parameters.AddWithValue("@Action", action);
            cmd.Parameters.AddWithValue("@UserId", data.UserId);

            if (action == 'I' || action == 'U')
                cmd.Parameters.AddWithValue("@Zone_Name", data.ZoneName);

            if (action != 'I')
                cmd.Parameters.AddWithValue("@Zone_Id", data.ZoneId);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            string result = "";
            while (await reader.ReadAsync())
                result = reader["msg"]?.ToString();

            return result;
        }

        public async Task<List<ZoneDto>> FetchZoneMasterAsync()
        {
            var result = new List<ZoneDto>();
            var connStr = _config.GetConnectionString("CoreDbConnectionString");

            using var conn = new SqlConnection(connStr);
            using var cmd = new SqlCommand("CRUD_Zone_Master", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Action", 'S');
            cmd.Parameters.AddWithValue("@UserId", 0);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new ZoneDto
                {
                    ZoneId = Convert.ToInt32(reader["Zone_Id"]),
                    ZoneName = reader["Zone_Name"]?.ToString(),
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
