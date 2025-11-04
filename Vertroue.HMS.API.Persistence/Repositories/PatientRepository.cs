using Vertroue.HMS.API.Application.Contracts.Persistence;
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
        #endregion 
    }
}
