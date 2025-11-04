using Microsoft.EntityFrameworkCore;
using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateContact;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateDoctorCommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateEmapnelledTPACommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateEmpanelledInsuranceCompany;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateHospital;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateMou;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateRenewal;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.CreateUser;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateContact;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateDoctorCommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateEmapnelledTPACommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateEmpanelledInsuranceCompanyCommand;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateHospital;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateMou;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateRenewal;
using Vertroue.HMS.API.Application.Features.Hospital.Commands.UpdateUser;
using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    public class HospitalRepository : BaseRepository<Hospital>, IHospitalRepository
    {
        public HospitalRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AddUpdateHospital(object hospital)
        {
            if (hospital is CreateHospitalCommand command)
            {
                var newHospital = new Hospital
                {
                    Name = command.Name,
                    Address = command.Address,
                    ContactNumber = command.ContactNumber,
                    WebSite = command.WebSite,
                    Email = command.Email,
                    IsActive = true,
                    CityId = command.CityId,
                    StateId = command.StateId
                };

                await AddAsync(newHospital);
            } 
            else if (hospital is UpdateHospitalCommand updateCommand)
            {
                var existingHospital = await GetByIdAsync(updateCommand.HospitalId);
                if (existingHospital == null)
                    throw new KeyNotFoundException($"Hospital with ID {updateCommand.HospitalId} not found.");

                if (existingHospital != null)
                {
                    existingHospital.Name = updateCommand.Name;
                    existingHospital.Address = updateCommand.Address;
                    existingHospital.ContactNumber = updateCommand.ContactNumber;
                    existingHospital.WebSite = updateCommand.WebSite;
                    existingHospital.Email = updateCommand.Email;
                    existingHospital.CityId = updateCommand.CityId;
                    existingHospital.StateId = updateCommand.StateId;
                    existingHospital.IsActive = updateCommand.IsActive;

                    await UpdateAsync(existingHospital);
                }
            }

            return true;
        }

        public async Task<Hospital?> GetHospitalDetailsByIdAsync(int id)
        {
            return await _dbContext.Hospitals
                .Include(h => h.City)
                .Include(h => h.State)
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.HospitalId == id);
        }

        public override async Task<IReadOnlyList<Hospital>> ListAllAsync()
        {
            return await _dbContext.Hospitals
                .Include(h => h.City)
                .Include(h => h.State)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> CreateNewRenewal(CreateRenewalCommand command)
        {
            var renewaldocs = new List<RenewalDoc>();
            foreach (var doc in command.Documents)
            {
                var renewalDoc = new RenewalDoc
                {
                    DocName = doc.Key,
                    DocUri = doc.Value,
                    IsActive = true
                };
                renewaldocs.Add(renewalDoc);
            }
            var renewal = new Renewal
            {
                HospitalId = command.HospitalId,
                Title = command.Title,
                Description = command.Description,
                IsActive = true,
                RenewalDate = command.RenewalDate,
                ExpireDate = command.ExpireDate,
                RenewalDocs = renewaldocs
            };
            await _dbContext.Renewals.AddAsync(renewal);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateRenewal(UpdateRenewalCommand command)
        {
            var existingRenewal = await _dbContext.Renewals
                .Include(r => r.RenewalDocs)
                .FirstOrDefaultAsync(r => r.RenewalId == command.RenewalId && r.HospitalId == command.HospitalId);

            if (existingRenewal == null)
                throw new KeyNotFoundException($"Renewal with ID {command.RenewalId} not found for Hospital ID {command.HospitalId}.");

            existingRenewal.Title = command.Title;
            existingRenewal.Description = command.Description;
            existingRenewal.RenewalDate = command.RenewalDate;
            existingRenewal.ExpireDate = command.ExpireDate;
            
            _dbContext.Update(existingRenewal);

            var renewaldocs = new List<RenewalDoc>();
            foreach (var doc in command.Documents)
            {
                var renewalDoc = new RenewalDoc
                {
                    DocName = doc.Key,
                    DocUri = doc.Value,
                    IsActive = true
                };
                renewaldocs.Add(renewalDoc);
            }

            if (renewaldocs.Any())
                await _dbContext.RenewalDocs.AddRangeAsync(renewaldocs);

            if (command.DocumentsToRemove != null 
                && command.DocumentsToRemove.Any())
            {
                var docsToRemove = existingRenewal.RenewalDocs
                    .Where(rd => command.DocumentsToRemove.Contains(rd.RenewalDocId))
                    .ToList();
                if (docsToRemove.Any())
                    _dbContext.RenewalDocs.RemoveRange(docsToRemove);
            }

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<RenewalDoc>> GetRenewalDocs(int renewalId)
        {
            return await _dbContext.RenewalDocs
                .Where(rd => rd.RenewalId == renewalId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> DisableRenewal(int renewalId)
        {
            var renewal = await _dbContext.Renewals.FindAsync(renewalId);
            renewal.IsActive = false;
            _dbContext.Update(renewal);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Renewal>> GetRenewalsForHospital(int hospitalId, int? renewalId)
        {
            var renewals = _dbContext.Renewals.Include(r => r.RenewalDocs)
                .Where(r => r.HospitalId == hospitalId);
                
            if (renewalId.HasValue && renewalId.Value > 0)
                renewals = renewals.Where(r => r.RenewalId == renewalId.Value);

            return await renewals.AsNoTracking().ToListAsync();
        }

        #region Empanelled Insurance company

        public async Task<bool> AddUpdateEmpanelledInsuranceCompany(object command)
        {
            if (command is CreateEmpanelledInsuranceCompanyCommand createCommand)
            {
                var newEmpanelledInsuranceCompany = new EmpanelledInsuranceCompany
                {
                    HospitalId = createCommand.HospitalId,
                    InsuranceCompanyId = createCommand.InsuranceCompanyId,
                    IsActive = true,
                    PassWord = createCommand.PassWord,
                    Portal = createCommand.Portal,
                    UserName = createCommand.UserName,
                    EmpanelledDate = createCommand.EmpanelledDate,
                };
                await _dbContext.EmpanelledInsuranceCompanies.AddAsync(newEmpanelledInsuranceCompany);
                await _dbContext.SaveChangesAsync();
            }
            else if (command is UpdateEmpanelledInsuranceCompanyCommand updateCommand)
            {
                var existingEntity = await _dbContext.EmpanelledInsuranceCompanies
                    .FirstOrDefaultAsync(e => e.EmpanelledInsCompId == updateCommand.EmpanelledInsCompId);

                if (existingEntity == null)
                    throw new KeyNotFoundException($"Empanelled Insurance Company with ID {updateCommand.EmpanelledInsCompId} not found.");

                existingEntity.InsuranceCompanyId = updateCommand.InsuranceCompanyId;
                existingEntity.Portal = updateCommand.Portal;
                existingEntity.UserName = updateCommand.UserName;
                existingEntity.PassWord = updateCommand.PassWord;
                existingEntity.EmpanelledDate = updateCommand.EmpanelledDate;
                
                _dbContext.Update(existingEntity);
                await _dbContext.SaveChangesAsync();
            }
            
            return true;
        }

        public async Task<List<EmpanelledInsuranceCompany>> GetEmpanelledInsuranceCompanies(int hospitalId, int? empanelledInsCompId)
        {
            var query = _dbContext.EmpanelledInsuranceCompanies
                .Include(e => e.InsuranceCompany)
                .Where(e => e.HospitalId == hospitalId);

            if (empanelledInsCompId.HasValue && empanelledInsCompId.Value > 0)
                query = query.Where(e => e.EmpanelledInsCompId == empanelledInsCompId.Value);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<bool> DisableEmpanelledInsuranceCompany(int empanelledInsCompId)
        {
            var empanelledInsuranceCompany = await _dbContext.EmpanelledInsuranceCompanies.FindAsync(empanelledInsCompId);
            empanelledInsuranceCompany.IsActive = false;
            _dbContext.Update(empanelledInsuranceCompany);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        #endregion

        #region EmpanelledTPA
        public async Task<List<EmpanelledTpa>> GetEmpanelledTpas(int hospitalId, int? empanelledTpaId)
        {
            var query = _dbContext.EmpanelledTpas
                .Include(e => e.Tpa)
                .Where(e => e.HospitalId == hospitalId);

            if (empanelledTpaId.HasValue && empanelledTpaId.Value > 0)
                query = query.Where(e => e.EmpanelledTpaId == empanelledTpaId.Value);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<bool> AddUpdateEmpanelledTpa(object command)
        {
            if (command is CreateEmapnelledTPACommand createCommand)
            {
                var newEmpanelledTpa = new EmpanelledTpa
                {
                    HospitalId = createCommand.HospitalId,
                    Tpaid = createCommand.TpaId,
                    IsActive = true,
                    PassWord = createCommand.PassWord,
                    Portal = createCommand.Portal,
                    UserName = createCommand.UserName,
                    EmpanelledDate = createCommand.EmpanelledDate,
                };
                await _dbContext.EmpanelledTpas.AddAsync(newEmpanelledTpa);
                await _dbContext.SaveChangesAsync();
            }
            else if (command is UpdateEmapnelledTPACommand updateCommand)
            {
                var existingEntity = await _dbContext.EmpanelledTpas
                    .FirstOrDefaultAsync(e => e.EmpanelledTpaId == updateCommand.EmpanelledTpaId);

                if (existingEntity == null)
                    throw new KeyNotFoundException($"Empanelled TPA with ID {updateCommand.EmpanelledTpaId} not found.");

                existingEntity.Tpaid = updateCommand.TpaId;
                existingEntity.Portal = updateCommand.Portal;
                existingEntity.UserName = updateCommand.UserName;
                existingEntity.PassWord = updateCommand.PassWord;
                existingEntity.EmpanelledDate = updateCommand.EmpanelledDate;

                _dbContext.Update(existingEntity);
                await _dbContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> DisableEmpanelledTpa(int empanelledTpaId)
        {
            var empanelledTPA = await _dbContext.EmpanelledTpas.FindAsync(empanelledTpaId);

            if (empanelledTPA == null)
                throw new KeyNotFoundException($"Empanelled TPA with ID {empanelledTpaId} not found.");

            empanelledTPA.IsActive = false;
            _dbContext.Update(empanelledTPA);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Doctors Master
        public async Task<List<DoctorsMaster>> GetDoctors(int hospitalId, int? doctorId)
        {
            var query = _dbContext.DoctorsMasters
                .Where(d => d.HospitalId == hospitalId);

            if (doctorId.HasValue && doctorId.Value > 0)
                query = query.Where(d => d.DoctorId == doctorId.Value);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<bool> AddUpdateDoctor(object doctor)
        {
            if (doctor is CreateDoctorCommand createCommand)
            {
                var newDoctor = new DoctorsMaster
                {
                    HospitalId = createCommand.HospitalId,
                    DoctorName = createCommand.DoctorName,
                    ContactNumber = createCommand.ContactNumber,
                    Qualification = createCommand.Qualification,
                    RegistrationNumber = createCommand.RegistrationNumber,
                    IsVisitingDoctor = createCommand.IsVisitingDoctor,
                    IsActive = true
                };
                await _dbContext.DoctorsMasters.AddAsync(newDoctor);
                await _dbContext.SaveChangesAsync();
            }
            else if (doctor is UpdateDoctorCommand updateCommand)
            {
                var existingDoctor = await _dbContext.DoctorsMasters
                    .FirstOrDefaultAsync(d => d.DoctorId == updateCommand.DoctorId);

                if (existingDoctor == null)
                    throw new KeyNotFoundException($"Doctor with ID {updateCommand.DoctorId} not found.");

                existingDoctor.DoctorName = updateCommand.DoctorName;
                existingDoctor.ContactNumber = updateCommand.ContactNumber;
                existingDoctor.Qualification = updateCommand.Qualification;
                existingDoctor.RegistrationNumber = updateCommand.RegistrationNumber;
                existingDoctor.IsVisitingDoctor = updateCommand.IsVisitingDoctor;

                _dbContext.Update(existingDoctor);
                await _dbContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> DisableDoctor(int doctorId)
        {
            var doctor = await _dbContext.DoctorsMasters.FindAsync(doctorId);
            doctor.IsActive = false;
            _dbContext.Update(doctor);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Contacts
        public async Task<bool> AddUpdateContact(object contact)
        {
            try
            {
                if (contact is CreateContactCommand createCommand)
                {
                    var newContact = new Contact
                    {
                        Name = createCommand.Name,
                        Email = createCommand.Email,
                        ContactNo = createCommand.ContactNo,
                        EmpanelledInsCompId = createCommand.EmpanelledInsCompId,
                        EmpanelledTpaId = createCommand.EmpanelledTpaId,
                        IsActive = true,
                        HospitalId = createCommand.HospitalId
                    };
                    await _dbContext.Contacts.AddAsync(newContact);
                    await _dbContext.SaveChangesAsync();
                }
                else if (contact is UpdateContactCommand updateCommand)
                {
                    var existingContact = await _dbContext.Contacts
                        .FirstOrDefaultAsync(c => c.ContactId == updateCommand.ContactId);

                    if (existingContact == null)
                        throw new KeyNotFoundException($"Contact with ID {updateCommand.ContactId} not found.");

                    existingContact.Name = updateCommand.Name;
                    existingContact.Email = updateCommand.Email;
                    existingContact.ContactNo = updateCommand.ContactNo;
                    existingContact.EmpanelledInsCompId = updateCommand.EmpanelledInsCompId;
                    existingContact.EmpanelledTpaId = updateCommand.EmpanelledTpaId;

                    _dbContext.Update(existingContact);
                    await _dbContext.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<List<Contact>> GetContacts(int hospitalId, int? empanelledInsCompId, int? empanelledTpaId, int? contactId)
        {
            var query = _dbContext.Contacts
                .Where(c => c.HospitalId == hospitalId);

            if (empanelledInsCompId.HasValue && empanelledInsCompId.Value > 0)
                query = query.Where(c => c.EmpanelledInsCompId == empanelledInsCompId.Value);

            if (empanelledTpaId.HasValue && empanelledTpaId.Value > 0)
                query = query.Where(c => c.EmpanelledTpaId == empanelledTpaId.Value);

            if (contactId.HasValue && contactId.Value > 0)
                query = query.Where(c => c.ContactId == contactId.Value);

            return await query
                .Include(c => c.EmpanelledInsComp).ThenInclude(e => e.InsuranceCompany)
                .Include(c => c.EmpanelledTpa).ThenInclude(e => e.Tpa)
                .AsNoTracking().ToListAsync();
        }

        public async Task<bool> DisableContact(int contactId)
        {
            var contact = await _dbContext.Contacts.FindAsync(contactId);
            if (contact == null)
                throw new KeyNotFoundException($"Contact with ID {contactId} not found.");
            contact.IsActive = false;
            _dbContext.Update(contact);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Mous
        public async Task<bool> AddUpdateMou(object command)
        {
            if (command is CreateMouCommand createCommand)
            {
                var newMou = new Mou
                {
                    EmpanelledInsCompId = createCommand.EmpanelledInsCompId,
                    EmpanelledTpaId = createCommand.EmpanelledTpaId,
                    DocName = createCommand.DocName,
                    DocUri = createCommand.DocUri,
                    MouStartDate = createCommand.MouStartDate,
                    MouEndDate = createCommand.MouEndDate,
                    HospitalId = createCommand.HospitalId,
                    IsActive = true
                };
                await _dbContext.Mous.AddAsync(newMou);
                await _dbContext.SaveChangesAsync();
            }
            else if (command is UpdateMouCommand updateCommand)
            {
                var existingMou = await _dbContext.Mous
                    .FirstOrDefaultAsync(m => m.Mouid == updateCommand.MouId);

                if (existingMou == null)
                    throw new KeyNotFoundException($"MOU with ID {updateCommand.MouId} not found.");

                existingMou.EmpanelledInsCompId = updateCommand.EmpanelledInsCompId;
                existingMou.EmpanelledTpaId = updateCommand.EmpanelledTpaId;
                existingMou.DocName = updateCommand.DocName;
                existingMou.DocUri = updateCommand.DocUri;
                existingMou.MouStartDate = updateCommand.MouStartDate;
                existingMou.MouEndDate = updateCommand.MouEndDate;

                _dbContext.Update(existingMou);
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<Mou>> GetMous(int hospitalId, int? empanelledInsCompId, int? empanelledTpaId, int? mouId)
        {
            var query = _dbContext.Mous
                .Where(m => m.HospitalId == hospitalId);

            if (empanelledInsCompId.HasValue && empanelledInsCompId.Value > 0)
                query = query.Where(m => m.EmpanelledInsCompId == empanelledInsCompId.Value);

            if (empanelledTpaId.HasValue && empanelledTpaId.Value > 0)
                query = query.Where(m => m.EmpanelledTpaId == empanelledTpaId.Value);

            if (mouId.HasValue && mouId.Value > 0)
                query = query.Where(m => m.Mouid == mouId.Value);

            return await query
                .Include(c => c.EmpanelledInsComp).ThenInclude(e => e.InsuranceCompany)
                .Include(c => c.EmpanelledTpa).ThenInclude(e => e.Tpa)
                .AsNoTracking().ToListAsync();
        }

        public async Task<bool> DisableMou(int mouId)
        {
            var mou = await _dbContext.Mous.FindAsync(mouId);
            if (mou == null)
                throw new KeyNotFoundException($"MOU with ID {mouId} not found.");
            mou.IsActive = false;
            _dbContext.Update(mou);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Hospital Users
        public async Task<bool> AddUpdateHospitalUser(object command)
        {
            try
            {
                if (command is CreateUserCommand createCommand)
                {
                    var user = new User
                    {
                        ContactNumber = createCommand.ContactNumber,
                        Email = createCommand.Email,
                        HospitalId = createCommand.HospitalId,
                        IsActive = true,
                        Name = createCommand.Name,
                        Password = createCommand.Password,
                        UserLoginId = createCommand.UserLoginId,
                        UserRoleId = createCommand.UserRoleId,
                    };
                    await _dbContext.Users.AddAsync(user);
                    await _dbContext.SaveChangesAsync();
                }
                else if (command is UpdateUserCommand updateCommand)
                {
                    var user = await _dbContext.Users
                        .FirstOrDefaultAsync(u => u.UserId == updateCommand.UserId);

                    if (user == null)
                        throw new KeyNotFoundException($"User with ID {updateCommand.UserId} not found.");

                    user.ContactNumber = updateCommand.ContactNumber;
                    user.Email = updateCommand.Email;
                    user.HospitalId = updateCommand.HospitalId;
                    user.Name = updateCommand.Name;
                    user.UserLoginId = updateCommand.UserLoginId;
                    user.UserRoleId = updateCommand.UserRoleId;
                    _dbContext.Update(user);
                    await _dbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }            
        }

        public async Task<List<User>> GetHospitalUsers(int? hospitalId, int? userId)
        {
            var query = _dbContext.Users
                .Include(u => u.UserRole)
                .Where(u => true);

            if (hospitalId.HasValue && hospitalId.Value > 0)
                query = query.Where(u => u.HospitalId == hospitalId.Value);

            if (userId.HasValue && userId.Value > 0)
                query = query.Where(u => u.UserId == userId.Value);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<bool> DisableHospitalUser(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            user.IsActive = false;
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
