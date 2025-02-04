﻿// <auto-generated />
using MachineLearningMachine3000.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MachineLearningMachine3000.Migrations
{
    [DbContext(typeof(DataContextLocal))]
    [Migration("20240409130447_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MachineLearningMachine3000.Shared.Entities.FactCaseForecast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DateId")
                        .HasColumnType("int");

                    b.Property<int>("SummeVonEingangNeuForecast")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FactCasesForecast");
                });
#pragma warning restore 612, 618
        }
    }
}
