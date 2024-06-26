﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitnessApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240418204905_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitnessApp.Models.Antrenament", b =>
                {
                    b.Property<int>("ID_Antrenament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Antrenament"));

                    b.Property<string>("Antrenament_Descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_Istoric")
                        .HasColumnType("int");

                    b.HasKey("ID_Antrenament");

                    b.ToTable("Antrenament");
                });

            modelBuilder.Entity("FitnessApp.Models.Exercitiu", b =>
                {
                    b.Property<int>("ID_Exercitiu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Exercitiu"));

                    b.Property<int>("AntrenamentID_Antrenament")
                        .HasColumnType("int");

                    b.Property<int>("Greutate_Adaugata")
                        .HasColumnType("int");

                    b.Property<int>("ID_Antrenament")
                        .HasColumnType("int");

                    b.Property<int>("Nr_Repetari")
                        .HasColumnType("int");

                    b.HasKey("ID_Exercitiu");

                    b.HasIndex("AntrenamentID_Antrenament");

                    b.ToTable("Exercitiu");
                });

            modelBuilder.Entity("FitnessApp.Models.Istoric", b =>
                {
                    b.Property<int>("ID_Istoric")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Istoric"));

                    b.Property<int>("ID_Antrenament")
                        .HasColumnType("int");

                    b.Property<int>("ID_Utilizator")
                        .HasColumnType("int");

                    b.Property<int>("UtilizatorID_Utilizator")
                        .HasColumnType("int");

                    b.HasKey("ID_Istoric");

                    b.HasIndex("ID_Antrenament")
                        .IsUnique();

                    b.HasIndex("UtilizatorID_Utilizator");

                    b.ToTable("Istoric");
                });

            modelBuilder.Entity("FitnessApp.Models.Masuratori", b =>
                {
                    b.Property<int>("ID_Masuratori")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Masuratori"));

                    b.Property<int>("Greutate")
                        .HasColumnType("int");

                    b.Property<int>("ID_Utilizator")
                        .HasColumnType("int");

                    b.HasKey("ID_Masuratori");

                    b.HasIndex("ID_Utilizator")
                        .IsUnique();

                    b.ToTable("Masuratori");
                });

            modelBuilder.Entity("FitnessApp.Models.Utilizator", b =>
                {
                    b.Property<int>("ID_Utilizator")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Utilizator"));

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Utilizator");

                    b.ToTable("Utilizatori");
                });

            modelBuilder.Entity("FitnessApp.Models.Exercitiu", b =>
                {
                    b.HasOne("FitnessApp.Models.Antrenament", "Antrenament")
                        .WithMany("Exercitii")
                        .HasForeignKey("AntrenamentID_Antrenament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Antrenament");
                });

            modelBuilder.Entity("FitnessApp.Models.Istoric", b =>
                {
                    b.HasOne("FitnessApp.Models.Antrenament", "Antrenament")
                        .WithOne("Istoric")
                        .HasForeignKey("FitnessApp.Models.Istoric", "ID_Antrenament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitnessApp.Models.Utilizator", "Utilizator")
                        .WithMany("Istoric")
                        .HasForeignKey("UtilizatorID_Utilizator")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Antrenament");

                    b.Navigation("Utilizator");
                });

            modelBuilder.Entity("FitnessApp.Models.Masuratori", b =>
                {
                    b.HasOne("FitnessApp.Models.Utilizator", "Utilizator")
                        .WithOne("Masuratori")
                        .HasForeignKey("FitnessApp.Models.Masuratori", "ID_Utilizator")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilizator");
                });

            modelBuilder.Entity("FitnessApp.Models.Antrenament", b =>
                {
                    b.Navigation("Exercitii");

                    b.Navigation("Istoric")
                        .IsRequired();
                });

            modelBuilder.Entity("FitnessApp.Models.Utilizator", b =>
                {
                    b.Navigation("Istoric");

                    b.Navigation("Masuratori")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
