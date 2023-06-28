﻿// <auto-generated />
using Dentistry.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dentistry.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dentistry.Domain.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Dentistry.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dentistry.Domain.Models.Doctor", b =>
                {
                    b.OwnsOne("System.Collections.Generic.List<string>", "Certificates", b1 =>
                        {
                            b1.Property<int>("DoctorId")
                                .HasColumnType("int");

                            b1.Property<int>("Capacity")
                                .HasColumnType("int");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("System.Collections.Generic.List<string>", "Education", b1 =>
                        {
                            b1.Property<int>("DoctorId")
                                .HasColumnType("int");

                            b1.Property<int>("Capacity")
                                .HasColumnType("int");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("Dentistry.Domain.Models.Doctor.PlacesOfWork#List", "PlacesOfWork", b1 =>
                        {
                            b1.Property<int>("DoctorId")
                                .HasColumnType("int");

                            b1.Property<int>("Capacity")
                                .HasColumnType("int");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("System.Collections.Generic.List<string>", "Reviews", b1 =>
                        {
                            b1.Property<int>("DoctorId")
                                .HasColumnType("int");

                            b1.Property<int>("Capacity")
                                .HasColumnType("int");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("System.Collections.Generic.List<Dentistry.Domain.Enums.Specialties>", "Specialties", b1 =>
                        {
                            b1.Property<int>("DoctorId")
                                .HasColumnType("int");

                            b1.Property<int>("Capacity")
                                .HasColumnType("int");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.OwnsOne("System.Collections.Generic.List<Dentistry.Domain.Models.Achievement>", "Achievements", b1 =>
                        {
                            b1.Property<int>("DoctorId")
                                .HasColumnType("int");

                            b1.Property<int>("Capacity")
                                .HasColumnType("int");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");
                        });

                    b.Navigation("Achievements");

                    b.Navigation("Certificates")
                        .IsRequired();

                    b.Navigation("Education")
                        .IsRequired();

                    b.Navigation("PlacesOfWork")
                        .IsRequired();

                    b.Navigation("Reviews")
                        .IsRequired();

                    b.Navigation("Specialties")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
