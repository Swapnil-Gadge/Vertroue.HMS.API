using Vertroue.HMS.API.Application.Contracts;
using Vertroue.HMS.API.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Vertroue.HMS.API.Persistence
{
    public class ApiDbContext: DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;

        public ApiDbContext(DbContextOptions<ApiDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CorporateMaster> Corporate_Master { get; set; }
        public DbSet<UserMaster> User_Master { get; set; }
        public DbSet<UserRoleMaster> User_Role_Master { get; set; }
        public DbSet<UserTypeMaster> User_Type_Master { get; set; }

        public virtual DbSet<CitiesMaster> CitiesMasters { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<EmpanelledInsuranceCompany> EmpanelledInsuranceCompanies { get; set; }

        public virtual DbSet<EmpanelledTpa> EmpanelledTpas { get; set; }

        public virtual DbSet<Hospital> Hospitals { get; set; }

        public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }

        public virtual DbSet<Mou> Mous { get; set; }

        public virtual DbSet<Renewal> Renewals { get; set; }

        public virtual DbSet<RenewalDoc> RenewalDocs { get; set; }

        public virtual DbSet<RoomType> RoomTypes { get; set; }

        public virtual DbSet<StatesMaster> StatesMasters { get; set; }

        public virtual DbSet<Tpa> Tpas { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }  

        public virtual DbSet<AdmissionType> AdmissionTypes { get; set; }
                
        public virtual DbSet<ClaimStatusMaster> ClaimStatusMasters { get; set; }

        public virtual DbSet<DischargeType> DischargeTypes { get; set; }

        public virtual DbSet<DoctorsMaster> DoctorsMasters { get; set; }

        public virtual DbSet<LineOfTreatment> LineOfTreatments { get; set; }

        public virtual DbSet<MedicalHistoriesMaster> MedicalHistoriesMasters { get; set; }

        public virtual DbSet<PackagesMaster> PackagesMasters { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<PatientDoc> PatientDocs { get; set; }

        public virtual DbSet<TparesponseCode> TparesponseCodes { get; set; }

        public virtual DbSet<TreatingDoctorDetail> TreatingDoctorDetails { get; set; }

        public virtual DbSet<TreatmentsMaster> TreatmentsMasters { get; set; }

        public virtual DbSet<ClaimFlow> ClaimFlows { get; set; }

        public virtual DbSet<ClaimFlowDoc> ClaimFlowDocs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);

            modelBuilder.Entity<CitiesMaster>(entity =>
            {
                entity.HasKey(e => e.CityId).HasName("PK__CitiesMa__F2D21A964AA0C19C");

                entity.ToTable("CitiesMaster");

                entity.Property(e => e.CityId).HasColumnName("CityID");
                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.HasOne(d => d.State).WithMany(p => p.CitiesMasters)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__CitiesMas__State__3335971A");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.ContactId).HasName("PK__Contacts__5C6625BBF01BB15C");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");
                entity.Property(e => e.ContactNo).HasColumnName("Contact");
                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Email)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.EmpanelledInsCompId).HasColumnName("EmpanelledInsCompId");
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.EmpanelledTpaId).HasColumnName("EmpanelledTpaId");

                entity.HasOne(d => d.Hospital).WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK__Contacts__Hospi__4C0144E4");

                entity.HasOne(d => d.EmpanelledInsComp).WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.EmpanelledInsCompId)
                    .HasConstraintName("FK__Contacts__Insura__4EDDB18F");

                entity.HasOne(d => d.EmpanelledTpa).WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.EmpanelledTpaId)
                    .HasConstraintName("FK__Contacts__TPAID__4FD1D5C8");
            });

            modelBuilder.Entity<EmpanelledInsuranceCompany>(entity =>
            {
                entity.HasKey(e => e.EmpanelledInsCompId).HasName("PK__Empanell__96AE1FED572102BE");

                entity.Property(e => e.EmpanelledInsCompId).HasColumnName("EmpanelledInsCompId");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
                entity.Property(e => e.InsuranceCompanyId).HasColumnName("InsuranceCompanyID");
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.EmpanelledDate).HasColumnType("EmpanelledDate");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.PassWord)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Portal)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hospital).WithMany(p => p.EmpanelledInsuranceCompanies)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK__Empanelle__Hospi__4830B400");

                entity.HasOne(d => d.InsuranceCompany).WithMany(p => p.EmpanelledInsuranceCompanies)
                    .HasForeignKey(d => d.InsuranceCompanyId)
                    .HasConstraintName("FK__Empanelle__Insur__473C8FC7");
            });

            modelBuilder.Entity<EmpanelledTpa>(entity =>
            {
                entity.HasKey(e => e.EmpanelledTpaId).HasName("PK__Empanell__96AE1FED28BD07CD");

                entity.ToTable("EmpanelledTPAs");

                entity.Property(e => e.EmpanelledTpaId).HasColumnName("EmpanelledTpaId");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.EmpanelledDate).HasColumnType("EmpanelledDate");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.PassWord)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Portal)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.Tpaid).HasColumnName("TPAID");
                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hospital).WithMany(p => p.EmpanelledTpas)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK__Empanelle__Hospi__4C0144E4");

                entity.HasOne(d => d.Tpa).WithMany(p => p.EmpanelledTpas)
                    .HasForeignKey(d => d.Tpaid)
                    .HasConstraintName("FK__Empanelle__TPAID__4B0D20AB");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(e => e.HospitalId).HasName("PK__Hospital__38C2E58FD2061A69");

                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
                entity.Property(e => e.Address).HasColumnType("text");
                entity.Property(e => e.CityId).HasColumnName("CityID");
                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.StateId).HasColumnName("StateID");
                entity.Property(e => e.WebSite)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.City).WithMany(p => p.Hospitals)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Hospitals__CityI__361203C5");

                entity.HasOne(d => d.State).WithMany(p => p.Hospitals)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Hospitals__State__370627FE");
            });

            modelBuilder.Entity<InsuranceCompany>(entity =>
            {
                entity.HasKey(e => e.InsuranceCompanyId).HasName("PK__Insuranc__CE9C94445A17F8F3");

                entity.Property(e => e.InsuranceCompanyId).HasColumnName("InsuranceCompanyID");
                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.WebSite)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mou>(entity =>
            {
                entity.HasKey(e => e.Mouid).HasName("PK__MOUs__066A690EDC4F2078");

                entity.ToTable("MOUs");

                entity.Property(e => e.Mouid).HasColumnName("MOUID");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DocName)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
                entity.Property(e => e.MouStartDate).HasColumnType("datetime");
                entity.Property(e => e.MouEndDate).HasColumnType("datetime");
                entity.Property(e => e.DocUri).IsUnicode(false);
                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
                entity.Property(e => e.EmpanelledInsCompId).HasColumnName("EmpanelledInsCompID");
                entity.Property(e => e.EmpanelledTpaId).HasColumnName("EmpanelledTpaID");
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hospital).WithMany(p => p.Mous)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK__MOUs__Hospi__4C0144E4");

                entity.HasOne(d => d.EmpanelledInsComp).WithMany(p => p.Mous)
                .HasForeignKey(d => d.EmpanelledInsCompId)
                .HasConstraintName("FK__MOUs__InsuranceC__436BFEE3");

                entity.HasOne(d => d.EmpanelledTpa).WithMany(p => p.Mous)
                    .HasForeignKey(d => d.EmpanelledTpaId)
                    .HasConstraintName("FK__MOUs__TPAID__4460231C");
            });

            modelBuilder.Entity<Renewal>(entity =>
            {
                entity.HasKey(e => e.RenewalId).HasName("PK__Renewals__AF5B6A21C323E36D");

                entity.Property(e => e.RenewalId).HasColumnName("RenewalID");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.RenewalDate).HasColumnType("datetime");
                entity.Property(e => e.ExpireDate).HasColumnType("datetime");
                entity.Property(e => e.Description)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hospital).WithMany(p => p.Renewals)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Renewals__Hospit__39E294A9");
            });

            modelBuilder.Entity<RenewalDoc>(entity =>
            {
                entity.HasKey(e => e.RenewalDocId).HasName("PK__RenewalD__9EF7CB00E9D8D968");

                entity.Property(e => e.RenewalDocId).HasColumnName("RenewalDocID");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DocName)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
                entity.Property(e => e.DocUri).IsUnicode(false);
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.RenewalId).HasColumnName("RenewalID");

                entity.HasOne(d => d.Renewal).WithMany(p => p.RenewalDocs)
                    .HasForeignKey(d => d.RenewalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RenewalDo__Renew__3CBF0154");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.HasKey(e => e.RoomTypeId).HasName("PK__RoomType__BCC89611FE27D5BC");

                entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatesMaster>(entity =>
            {
                entity.HasKey(e => e.StateId).HasName("PK__StatesMa__C3BA3B5A829B5AEE");

                entity.ToTable("StatesMaster");

                entity.Property(e => e.StateId).HasColumnName("StateID");
                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tpa>(entity =>
            {
                entity.HasKey(e => e.Tpaid).HasName("PK__TPAs__67C66ED80CA5A6A0");

                entity.ToTable("TPAs");

                entity.Property(e => e.Tpaid).HasColumnName("TPAID");
                entity.Property(e => e.Address)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
                entity.Property(e => e.Ceo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CEO");
                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Email)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.LicenseNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.LicenseValidTill).HasColumnType("date");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.WebSite)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACA3356CBF");

                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.UserLoginId)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.HasOne(d => d.Hospital).WithMany(p => p.Users)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK__Users__HospitalI__0169315C");

                entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__UserRoleI__025D5595");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A55D7AC8EB0");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdmissionType>(entity =>
            {
                entity.HasKey(e => e.AdmissionTypeId).HasName("PK__Admissio__05B4DA4DEBB9C3E9");

                entity.Property(e => e.AdmissionTypeId).HasColumnName("AdmissionTypeID");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClaimStatusMaster>(entity =>
            {
                entity.HasKey(e => e.ClaimStatusMasterId).HasName("PK__ClaimSta__62062F38BE22EF3B");

                entity.ToTable("ClaimStatusMaster");

                entity.Property(e => e.ClaimStatusMasterId).HasColumnName("ClaimStatusMasterID");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DischargeType>(entity =>
            {
                entity.HasKey(e => e.DischargeTypeId).HasName("PK__Discharg__7909E8181267C6E3");

                entity.Property(e => e.DischargeTypeId).HasColumnName("DischargeTypeID");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DoctorsMaster>(entity =>
            {
                entity.HasKey(e => e.DoctorId).HasName("PK__DoctorsM__2DC00EDF134249D5");

                entity.ToTable("DoctorsMaster");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DoctorName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Qualification)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hospital).WithMany(p => p.DoctorsMasters)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK__DoctorsM__Hospit__39E294A9");
            });

            modelBuilder.Entity<LineOfTreatment>(entity =>
            {
                entity.HasKey(e => e.LineOfTreatmentId).HasName("PK__LineOfTr__58AEDE0C9152C642");

                entity.Property(e => e.LineOfTreatmentId).HasColumnName("LineOfTreatmentID");
                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicalHistoriesMaster>(entity =>
            {
                entity.HasKey(e => e.HistoryMasterId).HasName("PK__MedicalH__51FD19238CDCB447");

                entity.ToTable("MedicalHistoriesMaster");

                entity.Property(e => e.HistoryMasterId).HasColumnName("HistoryMasterID");
                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PackagesMaster>(entity =>
            {
                entity.HasKey(e => e.PackageMasterId).HasName("PK__Packages__694477F1E2D8A1C3");

                entity.ToTable("PackagesMaster");

                entity.Property(e => e.PackageMasterId).HasColumnName("PackageMasterID");
                entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
                entity.Property(e => e.PackageName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.TpapayablePercent)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("TPAPayablePercent");

                entity.HasOne(d => d.Hospital).WithMany(p => p.PackagesMasters)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK__PackagesM__Hospi__6F4A8121");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC3461727349C");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");
                entity.Property(e => e.AccidentFirNumber)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.AccidentInjuryDate).HasColumnType("datetime");
                entity.Property(e => e.AdmissionDate).HasColumnType("date");
                entity.Property(e => e.AdmissionType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.AllInclusivePackageRs).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ClaimStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ClinicalFindings)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.ConsultationCharges).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.SubmitedDate).HasColumnType("datetime");
                entity.Property(e => e.DateOfBirth).HasColumnType("date");
                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
                entity.Property(e => e.DischargeDate).HasColumnType("datetime");
                entity.Property(e => e.DischargeTypeId).HasColumnName("DischargeTypeID");
                entity.Property(e => e.TreatingDoctorId).HasColumnName("TreatingDoctorID");
                entity.Property(e => e.DrugAdministrationRoute)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");
                entity.Property(e => e.ExpectedCost).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ExpectedInvestigationCost).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.FamilyPhysicianContact)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.FamilyPhysicianName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.FirstConsultationDate).HasColumnType("date");
                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
                entity.Property(e => e.Icd10PcsCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.Icd11Code)
                    .HasMaxLength(25)
                    .IsUnicode(false);
                entity.Property(e => e.IcuCharges).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.IllnessNature)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
                entity.Property(e => e.InjuryOccurrence)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
                entity.Property(e => e.InsuranceCompanyId).HasColumnName("InsuranceCompanyID");
                entity.Property(e => e.InsuredCardNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.InvestigationDetails)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.MaternityType)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.MedicinesConsumables).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.OtCharges).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.OtherAilmentDetails)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
                entity.Property(e => e.OtherInsuranceCompany)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.OtherTreatmentDetails)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.PastHistoryAilment)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PatientName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.PerDayRoomRent).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.PolicyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ProvisionalDiagnosis)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.RelativeContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.RoomType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.SubstanceAbuseReports)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.SurgicalDetails)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.TotalExpectedCost).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.TpaclaimId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TPAClaimID");
                entity.Property(e => e.Tpaid).HasColumnName("TPAID");
                entity.Property(e => e.TreatmentLine)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.DischargeType).WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DischargeTypeId)
                    .HasConstraintName("FK__Patients__Discha__60083D91");

                entity.HasOne(d => d.Hospital).WithMany(p => p.Patients)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patients__Hospit__5A4F643B");

                entity.HasOne(d => d.InsuranceCompany).WithMany(p => p.Patients)
                    .HasForeignKey(d => d.InsuranceCompanyId)
                    .HasConstraintName("FK__Patients__Insura__5B438874");

                entity.HasOne(d => d.Tpa).WithMany(p => p.Patients)
                    .HasForeignKey(d => d.Tpaid)
                    .HasConstraintName("FK__Patients__TPAID__5C37ACAD");

                entity.HasOne(d => d.TreatingDoctorDetails).WithMany(p => p.Patients)
                    .HasForeignKey(d => d.TreatingDoctorId)
                    .HasConstraintName("FK_Patients_Doctor_TreatingDocID");
            });

            modelBuilder.Entity<TparesponseCode>(entity =>
            {
                entity.HasKey(e => e.TparesponseCodeId).HasName("PK__TPARespo__A786B7D64D9641F8");

                entity.ToTable("TPAResponseCodes");

                entity.Property(e => e.TparesponseCodeId).HasColumnName("TPAResponseCodeID");
                entity.Property(e => e.QueryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.QueryDescription).HasColumnType("text");
            });

            modelBuilder.Entity<TreatingDoctorDetail>(entity =>
            {
                entity.HasKey(e => e.TreatingDoctorId).HasName("PK__Treating__077F7DB2F6CDFE08");

                entity.Property(e => e.TreatingDoctorId).HasColumnName("TreatingDoctorID");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Doctor).WithMany(p => p.TreatingDoctorDetails)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__TreatingD__Docto__10AB74EC");
            });

            modelBuilder.Entity<TreatmentsMaster>(entity =>
            {
                entity.HasKey(e => e.TreatmentMasterId).HasName("PK__Treatmen__1040CDBED10C4D3B");

                entity.ToTable("TreatmentsMaster");

                entity.Property(e => e.TreatmentMasterId).HasColumnName("TreatmentMasterID");
                entity.Property(e => e.TreatmentName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PatientDoc>(entity =>
            {
                entity.HasKey(e => e.PatientDocId).HasName("PK__PatientDocs__PRIMARY");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DocName)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
                entity.Property(e => e.DocUri).IsUnicode(false);
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.PatientId).HasColumnName("PatientID").IsRequired(false);
                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Patient).WithMany(p => p.PatientDocs)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientDocs__Patients_PatientID");
            });

            modelBuilder.Entity<ClaimFlow>(entity =>
            {
                entity.HasKey(e => e.ClaimFlowId).HasName("PK__ClaimFlo__D8C99EB8242AD3D9");

                entity.Property(e => e.ClaimFlowId).HasColumnName("ClaimFlowID");
                entity.Property(e => e.ApprovedAmount).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ClaimId).HasColumnName("ClaimID");
                entity.Property(e => e.ClaimPatientPayableAmount).HasColumnType("decimal(10, 2)");
                //entity.Property(e => e.ClaimStatusMasterId).HasColumnName("ClaimStatusMasterID");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.EstimatedAmount).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.FileFlowDateUpdated).HasColumnType("datetime");
                entity.Property(e => e.FileFlowId).HasColumnName("FileFlowID");
                entity.Property(e => e.FileFlowStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ReceiptNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.FinalSettlementAmount).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.AmountCouldNotRecovered).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.PackageMasterId).HasColumnName("PackageMasterID");
                entity.Property(e => e.PatientId).HasColumnName("PatientID");
                entity.Property(e => e.TpaApprovalReference)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.DischargeType)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.ResponseDocName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.ResponseDocument)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.ResponseId).HasColumnName("ResponseID");
                entity.Property(e => e.ResponseNotes).HasColumnType("text");
                entity.Property(e => e.ResponseType)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.QueryCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Stage)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.SubmittedDate).HasColumnType("datetime");
                entity.Property(e => e.SettlementDate).HasColumnType("datetime");
                entity.Property(e => e.TparesponseCodeId).HasColumnName("TPAResponseCodeID");
                entity.Property(e => e.TreatmentId).HasColumnName("TreatmentID");
                entity.Property(e => e.TreatmentMasterId).HasColumnName("TreatmentMasterID");
                entity.Property(e => e.TreatmentPatientPayableAmount).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.TreatmentDescription)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                //entity.HasOne(d => d.ClaimStatusMaster).WithMany(p => p.ClaimFlows)
                //    .HasForeignKey(d => d.ClaimStatusMasterId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_ClaimFlow_ClaimStatus");

                entity.HasOne(d => d.PackageMaster).WithMany(p => p.ClaimFlows)
                    .HasForeignKey(d => d.PackageMasterId)
                    .HasConstraintName("FK_ClaimFlow_PackageMaster");

                entity.HasOne(d => d.Patient).WithMany(p => p.ClaimFlows)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClaimFlow_Patient");

                entity.HasOne(d => d.TparesponseCode).WithMany(p => p.ClaimFlows)
                    .HasForeignKey(d => d.TparesponseCodeId)
                    .HasConstraintName("FK_ClaimFlow_TPAResponseCode");

                entity.HasOne(d => d.TreatmentMaster).WithMany(p => p.ClaimFlows)
                    .HasForeignKey(d => d.TreatmentMasterId)
                    .HasConstraintName("FK_ClaimFlow_TreatmentMaster");
            });

            modelBuilder.Entity<ClaimFlowDoc>(entity =>
            {
                entity.HasKey(e => e.ClaimFlowDocId).HasName("PK__ClaimFlowDocs__PRIMARY");

                entity.Property(e => e.ClaimFlowId).HasColumnName("ClaimFlowID");
                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DocName)
                    .HasMaxLength(5000)
                    .IsUnicode(false);
                entity.Property(e => e.DocUri).IsUnicode(false);
                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ClaimFlow).WithMany(p => p.ClaimFlowDocs)
                    .HasForeignKey(d => d.ClaimFlowId)
                    .HasConstraintName("FK__ClaimFlowDocs__ClaimFlows");
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            if (_loggedInUserService == null)
                throw new InvalidOperationException();

            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        var propInfo = entry.Entity.GetType().GetProperty("CreatedDate");
                        if (propInfo != null)
                        {
                            entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                            entry.Property("CreatedBy").CurrentValue = _loggedInUserService.UserName;
                        }                        
                        break;
                    case EntityState.Modified:
                        var updatedPropInfo = entry.Entity.GetType().GetProperty("LastUpdatedDate");
                        if (updatedPropInfo != null)
                        {
                            entry.Property("LastUpdatedDate").CurrentValue = DateTime.Now;
                            entry.Property("LastUpdatedBy").CurrentValue = _loggedInUserService.UserName;
                        }
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
