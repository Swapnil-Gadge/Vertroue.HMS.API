using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Patient.Commands.CreateClaimFlowDoc;
using Vertroue.HMS.API.Application.Features.Patient.Commands.CreatePatientDoc;
using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }

        #region Patient doc
        public async Task<int> CreatePatientDoc(CreatePatientDocCommand cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            var patientDoc = new PatientDoc
            {
                DocName = cmd.FileName,
                DocUri = cmd.FileUrl,
                PatientId = cmd.PatientId > 0 ? cmd.PatientId : null,
                IsActive = cmd.PatientId > 0,
                Title = cmd.DocumentType
            };

            await _dbContext.PatientDocs.AddAsync(patientDoc);
            await _dbContext.SaveChangesAsync();
            return patientDoc.PatientDocId;
        }

        public async Task<string> DeletePatientDoc(int patientDocId)
        {
            var patientDoc = await _dbContext.PatientDocs.FirstOrDefaultAsync(p => p.PatientDocId == patientDocId);
            if (patientDoc == null)
                return string.Empty;

            _dbContext.PatientDocs.Remove(patientDoc);
            await _dbContext.SaveChangesAsync();
            return patientDoc.DocUri;
        }

        public async Task<List<PatientDoc?>> GetPatientDocsByPatientIdAsync(int patientId)
        {
            return await _dbContext.PatientDocs.Where(p => p.PatientId == patientId).ToListAsync();
        }

        public async Task<List<Patient>> GetPatientsByHospitalIdAsync(int hospitalId)
        {
            Expression<Func<Patient, bool>> predicate = (p) => true;

            if (hospitalId > 0)
                predicate = (p) => p.HospitalId == hospitalId;
            
            return await _dbContext.Patients
                .Include(p => p.InsuranceCompany)
                .Include(p => p.Tpa).AsNoTracking()
                .Where(predicate).ToListAsync();
        }
        #endregion

        #region Claim flow Doc
        public async Task<int> CreateClaimFlowDoc(CreateClaimFlowDocCommand cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            var claimFlowDoc = new ClaimFlowDoc
            {
                DocName = cmd.FileName,
                DocUri = cmd.FileUrl,                
                IsActive = false,
            };

            await _dbContext.ClaimFlowDocs.AddAsync(claimFlowDoc);
            await _dbContext.SaveChangesAsync();
            return claimFlowDoc.ClaimFlowDocId;
        }

        public async Task<string> DeleteClaimFlowDoc(int claimFlowDocId)
        {
            var claimFlowDoc = await _dbContext.ClaimFlowDocs.FirstOrDefaultAsync(p => p.ClaimFlowDocId == claimFlowDocId);
            if (claimFlowDoc == null)
                return string.Empty;

            _dbContext.ClaimFlowDocs.Remove(claimFlowDoc);
            await _dbContext.SaveChangesAsync();
            return claimFlowDoc.DocUri;
        }

        public async Task<bool> UpdateClaimFlowDocs(List<int> ids, int claimflowId)
        {
            var claimFlows = await _dbContext.ClaimFlowDocs.Where(c => ids.Contains(c.ClaimFlowDocId)).ToListAsync();
            if (claimFlows == null || claimFlows.Count == 0)
                return false;

            foreach (var claimFlow in claimFlows)
            {
                claimFlow.ClaimFlowId = claimflowId;
                claimFlow.IsActive = true;
            }

            _dbContext.ClaimFlowDocs.UpdateRange(claimFlows);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ClaimFlowDoc?>> GetClaimFlowDocsByClaimFlowIdAsync(int claimFlowId)
        {
            return await _dbContext.ClaimFlowDocs.Where(c => c.ClaimFlowId == claimFlowId).ToListAsync();
        }
        #endregion

        #region Add Update Patient
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            await _dbContext.Patients.AddAsync(patient);
            await _dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            _dbContext.Patients.Update(patient);
            await _dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient?> GetPatientByIdAsync(int patientId, bool onlyPatient = false)
        {
            if (onlyPatient)
            {
                return await _dbContext.Patients.AsNoTracking()
                    .FirstOrDefaultAsync(p => p.PatientId == patientId);
            }

            return await _dbContext.Patients
                .Include(p => p.InsuranceCompany)
                .Include(p => p.Tpa)
                .Include(p => p.TreatingDoctorDetails)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PatientId == patientId);
        }

        public async Task<bool> UpdatePatientDocsFlag(List<int> ids, int patientId)
        {
            var patientDocs = _dbContext.PatientDocs.Where(p => ids.Contains(p.PatientDocId)).ToList();
            if (patientDocs == null || patientDocs.Count == 0)
                return false;

            foreach (var doc in patientDocs)
            {
                doc.IsActive = true;
                doc.PatientId = patientId;
            }

            _dbContext.PatientDocs.UpdateRange(patientDocs);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateClaimStatus(int patientId, string status)
        {
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.PatientId == patientId);
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            patient.ClaimStatus = status;
            _dbContext.Patients.Update(patient);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Claim Flow
        public async Task<ClaimFlow> AddClaimFlowAsync(ClaimFlow claimFlow)
        {
            if (claimFlow == null)
                throw new ArgumentNullException(nameof(claimFlow));

            await _dbContext.ClaimFlows.AddAsync(claimFlow);
            await _dbContext.SaveChangesAsync();
            return claimFlow;
        }

        public async Task<ClaimFlow> UpdateClaimFlowAsync(ClaimFlow claimFlow)
        {
            if (claimFlow == null)
                throw new ArgumentNullException(nameof(claimFlow));

            _dbContext.ClaimFlows.Update(claimFlow);
            await _dbContext.SaveChangesAsync();
            return claimFlow;
        }

        public async Task<List<ClaimFlow?>> GetClaimFlowByPatientIdAsync(int patientId)
        {
            return await _dbContext.ClaimFlows
                .Include(c => c.TreatmentMaster)
                .Include(c => c.PackageMaster)
                .Where(c => c.PatientId == patientId).AsNoTracking().ToListAsync();
        }

        public async Task<bool> DeleteClaimFlow(int claimFlowId)
        {
            var claimflow = await _dbContext.ClaimFlows.FirstOrDefaultAsync(c => c.ClaimFlowId == claimFlowId);
            if (claimflow == null)
                throw new ArgumentNullException(nameof(claimflow));

            _dbContext.ClaimFlows.Remove(claimflow);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ClaimFlow?> GetClaimFlowByIdAsync(int claimFlowId)
        {
            return await _dbContext.ClaimFlows.AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClaimFlowId == claimFlowId);
        }
        #endregion
    }
}
