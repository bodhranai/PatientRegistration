using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PatientRegistration.Infrastructure.Models;

public partial class PatientRegistrationContext : DbContext
{
    public PatientRegistrationContext()
    {
    }

    public PatientRegistrationContext(DbContextOptions<PatientRegistrationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PatientDetail> PatientDetails { get; set; }

    public virtual DbSet<Patient_Lab_Result> Patient_Lab_Results { get; set; }

    public virtual DbSet<Patient_Lab_Visit> Patient_Lab_Visits { get; set; }

    public virtual DbSet<Patient_Medication> Patient_Medications { get; set; }

    public virtual DbSet<Patient_Vaccination_Data> Patient_Vaccination_Data { get; set; }

    public virtual DbSet<Patient_Visit_History> Patient_Visit_Histories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=PatientRegistration;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PatientDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.address).HasMaxLength(50);
            entity.Property(e => e.city).HasMaxLength(50);
            entity.Property(e => e.first_name).HasMaxLength(50);
            entity.Property(e => e.last_name).HasMaxLength(50);
            entity.Property(e => e.middle_name).HasMaxLength(50);
            entity.Property(e => e.state)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.zip)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Patient_Lab_Result>(entity =>
        {
            entity.ToTable("Patient_Lab_Result");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Attachments).HasMaxLength(50);
            entity.Property(e => e.Test_name).HasMaxLength(50);
            entity.Property(e => e.Test_observation).HasMaxLength(50);
            entity.Property(e => e.Test_result).HasMaxLength(50);
        });

        modelBuilder.Entity<Patient_Lab_Visit>(entity =>
        {
            entity.ToTable("Patient_Lab_Visit");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Lab_name).HasMaxLength(50);
            entity.Property(e => e.Lab_test_request).HasMaxLength(50);
            entity.Property(e => e.Result_date).HasMaxLength(50);
        });

        modelBuilder.Entity<Patient_Medication>(entity =>
        {
            entity.HasKey(e => new { e.Patient_id, e.Visit_id });

            entity.ToTable("Patient_Medication");

            entity.Property(e => e.Dosage).HasMaxLength(50);
            entity.Property(e => e.Frequency).HasMaxLength(50);
            entity.Property(e => e.Medicine_Name).HasMaxLength(50);
            entity.Property(e => e.Prescribed_By).HasMaxLength(50);
            entity.Property(e => e.Prescription_Date).HasMaxLength(50);
            entity.Property(e => e.Prescription_period).HasMaxLength(50);
        });

        modelBuilder.Entity<Patient_Vaccination_Data>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Administered_by).HasMaxLength(50);
            entity.Property(e => e.Vaccine_name).HasMaxLength(50);
        });

        modelBuilder.Entity<Patient_Visit_History>(entity =>
        {
            entity.ToTable("Patient_Visit_History");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Doctor_Name).HasMaxLength(50);
            entity.Property(e => e.Nurse_Name1).HasMaxLength(50);
            entity.Property(e => e.Nurse_Name2).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
