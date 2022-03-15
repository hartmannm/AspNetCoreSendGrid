using ANCSG.Domain.Contexts.PatientContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ANCSG.Infra.Data.Mappings
{
    public class PatientMap : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.OwnsOne(x => x.Name, cb =>
            {
                cb.Property(n => n.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName");

                cb.Property(n => n.LastName)
                    .IsRequired()
                    .HasColumnName("LastName");
            });

            builder.OwnsOne(x => x.Email, cb =>
            {
                cb.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("Email");

                cb.HasIndex(e => e.Address)
                    .IsUnique();
            });

            builder.Property(x => x.BirthDate)
                .IsRequired();

            builder.HasMany(x => x.MedicalExams)
                .WithOne(me => me.Patient);

            builder.ToTable("Patients");
        }
    }
}
