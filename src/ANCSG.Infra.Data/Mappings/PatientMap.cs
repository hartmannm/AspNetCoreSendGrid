using ANCSG.Domain.Contexts.PatientContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ANCSG.Infra.Data.Mappings
{
    public class PatientMap : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.BirthDate)
                .IsRequired();

            builder.HasMany(x => x.MedicalExams)
                .WithOne(me => me.Patient);

            builder.ToTable("Patients");
        }
    }
}
