using ANCSG.Domain.Contexts.MedicalExamContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ANCSG.Infra.Data.Mappings
{
    public class MedicalExamMap : IEntityTypeConfiguration<MedicalExam>
    {
        public void Configure(EntityTypeBuilder<MedicalExam> builder)
        {
            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(30);

            builder.HasOne(x => x.Doctor)
                .WithMany(d => d.MedicalExams)
                .HasForeignKey(x => x.DoctorId);

            builder.HasOne(x => x.Patient)
                .WithMany(p => p.MedicalExams)
                .HasForeignKey(x => x.PatientId);

            builder.ToTable("MedicalExams");
        }
    }
}
