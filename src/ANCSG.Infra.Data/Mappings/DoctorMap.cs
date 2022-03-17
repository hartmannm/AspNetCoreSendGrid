using ANCSG.Domain.Contexts.DoctorContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ANCSG.Infra.Data.Mappings
{
    public class DoctorMap : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
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

            builder.OwnsOne(x => x.CRM, cb =>
            {
                cb.Property(c => c.Uf)
                    .HasConversion<string>()
                    .HasMaxLength(2)
                    .IsRequired()
                    .HasColumnName("CrmUf");

                cb.Property(c => c.Number)
                    .IsRequired()
                    .HasColumnName("CrmNumber");

                cb.HasIndex(c => new { c.Uf, c.Number })
                    .IsUnique();
            });

            builder.HasMany(x => x.MedicalExams)
                .WithOne(me => me.Doctor);

            builder.ToTable("Doctors");
        }
    }
}
