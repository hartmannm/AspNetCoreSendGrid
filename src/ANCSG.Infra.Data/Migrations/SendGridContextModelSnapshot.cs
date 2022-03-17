﻿// <auto-generated />
using System;
using ANCSG.Infra.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ANCSG.Infra.Data.Migrations
{
    [DbContext(typeof(SendGridContext))]
    partial class SendGridContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Send-Grid")
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ANCSG.Domain.Contexts.DoctorContext.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Doctors", "Send-Grid");
                });

            modelBuilder.Entity("ANCSG.Domain.Contexts.MedicalExamContext.Entities.MedicalExam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalExams", "Send-Grid");
                });

            modelBuilder.Entity("ANCSG.Domain.Contexts.PatientContext.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Patients", "Send-Grid");
                });

            modelBuilder.Entity("ANCSG.Domain.Contexts.DoctorContext.Entities.Doctor", b =>
                {
                    b.OwnsOne("ANCSG.Domain.DomainEntities.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("varchar(255)")
                                .HasColumnName("Email");

                            b1.HasKey("DoctorId");

                            b1.HasIndex("Address")
                                .IsUnique()
                                .HasFilter("[Email] IS NOT NULL");

                            b1.ToTable("Doctors", "Send-Grid");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("ANCSG.Domain.DomainEntities.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("varchar(255)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("varchar(255)")
                                .HasColumnName("LastName");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors", "Send-Grid");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("ANCSG.Domain.Contexts.DoctorContext.ValueObjects.CRMRegister", "CRM", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<long>("Number")
                                .HasColumnType("bigint")
                                .HasColumnName("CrmNumber");

                            b1.Property<string>("Uf")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("nvarchar(2)")
                                .HasColumnName("CrmUf");

                            b1.HasKey("DoctorId");

                            b1.HasIndex("Uf", "Number")
                                .IsUnique()
                                .HasFilter("[CrmUf] IS NOT NULL AND [CrmNumber] IS NOT NULL");

                            b1.ToTable("Doctors", "Send-Grid");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.Navigation("CRM");

                    b.Navigation("Email");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("ANCSG.Domain.Contexts.MedicalExamContext.Entities.MedicalExam", b =>
                {
                    b.HasOne("ANCSG.Domain.Contexts.DoctorContext.Entities.Doctor", "Doctor")
                        .WithMany("MedicalExams")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ANCSG.Domain.Contexts.PatientContext.Entities.Patient", "Patient")
                        .WithMany("MedicalExams")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("ANCSG.Domain.Contexts.PatientContext.Entities.Patient", b =>
                {
                    b.OwnsOne("ANCSG.Domain.DomainEntities.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)")
                                .HasColumnName("Email");

                            b1.HasKey("PatientId");

                            b1.HasIndex("Address")
                                .IsUnique()
                                .HasFilter("[Email] IS NOT NULL");

                            b1.ToTable("Patients", "Send-Grid");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.OwnsOne("ANCSG.Domain.DomainEntities.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LastName");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patients", "Send-Grid");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.Navigation("Email");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("ANCSG.Domain.Contexts.DoctorContext.Entities.Doctor", b =>
                {
                    b.Navigation("MedicalExams");
                });

            modelBuilder.Entity("ANCSG.Domain.Contexts.PatientContext.Entities.Patient", b =>
                {
                    b.Navigation("MedicalExams");
                });
#pragma warning restore 612, 618
        }
    }
}
