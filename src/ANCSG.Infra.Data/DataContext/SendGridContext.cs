using ANCSG.Domain.Contexts.DoctorContext.Entities;
using ANCSG.Domain.Contexts.MedicalExamContext.Entities;
using ANCSG.Domain.Contexts.PatientContext.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ANCSG.Infra.Data.DataContext
{
    public class SendGridContext : DbContext
    {
        public DbSet<Patient> Patients { get; private set; }

        public DbSet<Doctor> Doctors { get; private set; }

        public DbSet<MedicalExam> MedicalExams { get; private set; }

        public SendGridContext(DbContextOptions<SendGridContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Send-Grid");
            ConfigureStringDefaultLength(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SendGridContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureStringDefaultLength(ModelBuilder modelBuilder)
        {
            var properties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string)));

            foreach (var property in properties)
                property.SetColumnType("varchar(255)");
        }
    }
}
