using ANCSG.Domain.Contexts.DoctorContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ANCSG.Infra.Data.Mappings
{
    public class DoctorMap : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.CRMUF)
                .HasConversion<string>()
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(x => x.CRMNumber)
                .IsRequired();

            builder.HasMany(x => x.MedicalExams)
                .WithOne(me => me.Doctor);

            builder.ToTable("Doctors");
        }
    }
}
