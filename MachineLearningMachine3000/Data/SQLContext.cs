using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MachineLearningMachine3000.Data;

public partial class SQLContext : DbContext
{
    public SQLContext()
    {
    }

    public SQLContext(DbContextOptions<SQLContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DimDate> DimDates { get; set; }

    public virtual DbSet<FactCase> FactCases { get; set; }

    public virtual DbSet<VwFactCase> VwFactCases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sqltoolkit.database.windows.net,1433;Database=DataScience;User Id=Heringer_DataScience;Password=Köln2024!;Integrated Security=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DimDate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Dim_Date", "DP_FC_156");

            entity.Property(e => e.AnzahlVonNextWorkDayDateId)
                .HasMaxLength(1)
                .HasColumnName("Anzahl_von_NextWorkDayDateID");
            entity.Property(e => e.DateId).HasColumnName("DateID");
            entity.Property(e => e.DayName).HasMaxLength(50);
            entity.Property(e => e.Holiday).HasMaxLength(50);
            entity.Property(e => e.Monat).HasMaxLength(50);
            entity.Property(e => e.MonthName).HasMaxLength(50);
            entity.Property(e => e.Quartal).HasMaxLength(50);
            entity.Property(e => e.QuaterName).HasMaxLength(50);
            entity.Property(e => e.SummeVonDayOfMonthNr).HasColumnName("Summe_von_DayOfMonthNr");
            entity.Property(e => e.SummeVonDayOfWeekNr).HasColumnName("Summe_von_DayOfWeekNr");
            entity.Property(e => e.SummeVonMonthNr).HasColumnName("Summe_von_MonthNr");
            entity.Property(e => e.SummeVonQuarterNr).HasColumnName("Summe_von_QuarterNr");
            entity.Property(e => e.SummeVonWeekNr).HasColumnName("Summe_von_WeekNr");
            entity.Property(e => e.SummeVonYearNr).HasColumnName("Summe_von_YearNr");
            entity.Property(e => e.WeekName).HasMaxLength(50);
            entity.Property(e => e.YearMonthName).HasMaxLength(50);
            entity.Property(e => e.YearQuater).HasMaxLength(50);
            entity.Property(e => e.YearWeekName).HasMaxLength(50);
        });

        modelBuilder.Entity<FactCase>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Fact_Cases", "DP_FC_156");

            entity.Property(e => e.ServiceIdId).HasColumnName("ServiceID_ID");
            entity.Property(e => e.SummeVonEingangAktiv).HasColumnName("Summe_von_Eingang_Aktiv");
            entity.Property(e => e.SummeVonEingangNeu).HasColumnName("Summe_von_Eingang_Neu");
        });

        modelBuilder.Entity<VwFactCase>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_Fact_Cases", "DP_FC_156");

            entity.Property(e => e.DayName).HasMaxLength(50);
            entity.Property(e => e.EingangAktiv).HasColumnName("Eingang_Aktiv");
            entity.Property(e => e.EingangNeu).HasColumnName("Eingang_Neu");
            entity.Property(e => e.Holiday).HasMaxLength(50);
            entity.Property(e => e.Monat).HasMaxLength(50);
            entity.Property(e => e.MonthName).HasMaxLength(50);
            entity.Property(e => e.NextWorkDayDateId)
                .HasMaxLength(1)
                .HasColumnName("NextWorkDayDateID");
            entity.Property(e => e.Quartal).HasMaxLength(50);
            entity.Property(e => e.QuaterName).HasMaxLength(50);
            entity.Property(e => e.ServiceIdId).HasColumnName("ServiceID_ID");
            entity.Property(e => e.WeekName).HasMaxLength(50);
            entity.Property(e => e.YearMonthName).HasMaxLength(50);
            entity.Property(e => e.YearQuater).HasMaxLength(50);
            entity.Property(e => e.YearWeekName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
