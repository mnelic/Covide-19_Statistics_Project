using CovidApp_Part2.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CovidApp_Part2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientStatus> PatientStatuses { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gender>().ToTable("Gender");
            modelBuilder.Entity<Lab>().ToTable("Lab");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<PatientStatus>().ToTable("PatientStatus");
            modelBuilder.Entity<Province>().ToTable("Province");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Test>().ToTable("Test");
            modelBuilder.Entity<TestResult>().ToTable("TestResult");

            modelBuilder.Entity<Gender>().HasData(
                new Gender { GenderId = 1, GenderName = "Female" },
                new Gender { GenderId = 2, GenderName = "Male" }
                );


            modelBuilder.Entity<Lab>().HasData(
                new Lab { LabId = 1, LabName = "Private" },
                new Lab { LabId = 2, LabName = "Public" }
                );

            modelBuilder.Entity<Province>().HasData(
                new Province { ProvinceId = 1, ProvinceName = "Eastern Cape", ProvinceAbbreviation = "EC" },
                new Province { ProvinceId = 2, ProvinceName = "Free State", ProvinceAbbreviation = "FS" },
                new Province { ProvinceId = 3, ProvinceName = "Gauteng", ProvinceAbbreviation = "GP" },
                new Province { ProvinceId = 4, ProvinceName = "KwaZulu-Natal", ProvinceAbbreviation = "KZN" },
                new Province { ProvinceId = 5, ProvinceName = "Limpopo", ProvinceAbbreviation = "L" },
                new Province { ProvinceId = 6, ProvinceName = "Mpumalanga", ProvinceAbbreviation = "MP" },
                new Province { ProvinceId = 7, ProvinceName = "Northern Cape", ProvinceAbbreviation = "NC" },
                new Province { ProvinceId = 8, ProvinceName = "North West", ProvinceAbbreviation = "NW" },
                new Province { ProvinceId = 9, ProvinceName = "Western Cape", ProvinceAbbreviation = "WC" }
                );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusName = "Active" },
                new Status { StatusId = 2, StatusName = "Deceased" },
                new Status { StatusId = 3, StatusName = "Recovered" },
                new Status { StatusId = 4, StatusName = "Not infected" }
                );

            modelBuilder.Entity<TestResult>().HasData(
                new TestResult { TestResultId = 1, TestResultName = "Positive" },
                new TestResult { TestResultId = 2, TestResultName = "Negative" }
                );

            modelBuilder.Entity<PatientStatus>().HasData(
                new PatientStatus { PatientStatusId = 1, PatientId = 1, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-03") },
                new PatientStatus { PatientStatusId = 2, PatientId = 2, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-07") },
                new PatientStatus { PatientStatusId = 3, PatientId = 3, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-10") },
                new PatientStatus { PatientStatusId = 4, PatientId = 4, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-10") },
                new PatientStatus { PatientStatusId = 5, PatientId = 5, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-10") },
                new PatientStatus { PatientStatusId = 6, PatientId = 6, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-10") },
                new PatientStatus { PatientStatusId = 7, PatientId = 7, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-10") },

                new PatientStatus { PatientStatusId = 8, PatientId = 8, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-11") },
                new PatientStatus { PatientStatusId = 9, PatientId = 9, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-11") },
                new PatientStatus { PatientStatusId = 10, PatientId = 10, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-11") },
                new PatientStatus { PatientStatusId = 11, PatientId = 11, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-11") },
                new PatientStatus { PatientStatusId = 12, PatientId = 12, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-11") },
                new PatientStatus { PatientStatusId = 13, PatientId = 13, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-11") },

                new PatientStatus { PatientStatusId = 14, PatientId = 14, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-12") },
                new PatientStatus { PatientStatusId = 15, PatientId = 15, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-12") },
                new PatientStatus { PatientStatusId = 16, PatientId = 16, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-12") },
                new PatientStatus { PatientStatusId = 17, PatientId = 17, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-12") },

                new PatientStatus { PatientStatusId = 18, PatientId = 18, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-13") },
                new PatientStatus { PatientStatusId = 19, PatientId = 19, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-13") },
                new PatientStatus { PatientStatusId = 20, PatientId = 20, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-13") },
                new PatientStatus { PatientStatusId = 21, PatientId = 21, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-13") },
                new PatientStatus { PatientStatusId = 22, PatientId = 22, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-13") },
                new PatientStatus { PatientStatusId = 23, PatientId = 23, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-13") },
                new PatientStatus { PatientStatusId = 24, PatientId = 24, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-13") },

                new PatientStatus { PatientStatusId = 25, PatientId = 25, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 26, PatientId = 26, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 27, PatientId = 27, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 28, PatientId = 28, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 29, PatientId = 29, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 30, PatientId = 30, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 31, PatientId = 31, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 32, PatientId = 32, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 33, PatientId = 33, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 34, PatientId = 34, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 35, PatientId = 35, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 36, PatientId = 36, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 37, PatientId = 37, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },
                new PatientStatus { PatientStatusId = 38, PatientId = 38, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-14") },

                new PatientStatus { PatientStatusId = 39, PatientId = 39, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },
                new PatientStatus { PatientStatusId = 40, PatientId = 40, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },
                new PatientStatus { PatientStatusId = 41, PatientId = 41, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },
                new PatientStatus { PatientStatusId = 42, PatientId = 42, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },
                new PatientStatus { PatientStatusId = 43, PatientId = 43, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },
                new PatientStatus { PatientStatusId = 44, PatientId = 44, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },
                new PatientStatus { PatientStatusId = 45, PatientId = 45, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },
                new PatientStatus { PatientStatusId = 46, PatientId = 46, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },
                new PatientStatus { PatientStatusId = 47, PatientId = 47, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },
                new PatientStatus { PatientStatusId = 48, PatientId = 48, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },
                new PatientStatus { PatientStatusId = 49, PatientId = 49, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },
                new PatientStatus { PatientStatusId = 50, PatientId = 50, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },
                new PatientStatus { PatientStatusId = 51, PatientId = 51, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-15") },

                new PatientStatus { PatientStatusId = 52, PatientId = 52, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-16") },
                new PatientStatus { PatientStatusId = 53, PatientId = 53, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-16") },
                new PatientStatus { PatientStatusId = 54, PatientId = 54, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-16") },
                new PatientStatus { PatientStatusId = 55, PatientId = 55, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-16") },
                new PatientStatus { PatientStatusId = 56, PatientId = 56, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-16") },
                new PatientStatus { PatientStatusId = 57, PatientId = 57, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-16") },
                new PatientStatus { PatientStatusId = 58, PatientId = 58, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-16") },
                new PatientStatus { PatientStatusId = 59, PatientId = 59, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-16") },
                new PatientStatus { PatientStatusId = 60, PatientId = 60, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-16") },
                new PatientStatus { PatientStatusId = 61, PatientId = 61, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-16") },
                new PatientStatus { PatientStatusId = 62, PatientId = 62, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-16") },

                new PatientStatus { PatientStatusId = 63, PatientId = 63, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 64, PatientId = 64, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 65, PatientId = 65, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 66, PatientId = 66, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 67, PatientId = 67, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 68, PatientId = 68, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 69, PatientId = 69, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 70, PatientId = 70, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 71, PatientId = 71, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 72, PatientId = 72, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 73, PatientId = 73, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 74, PatientId = 74, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 75, PatientId = 75, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 76, PatientId = 76, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 77, PatientId = 77, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 78, PatientId = 78, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 79, PatientId = 79, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 80, PatientId = 80, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 81, PatientId = 81, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 82, PatientId = 82, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 83, PatientId = 83, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 84, PatientId = 84, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },
                new PatientStatus { PatientStatusId = 85, PatientId = 85, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-17") },

                new PatientStatus { PatientStatusId = 86, PatientId = 86, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 87, PatientId = 87, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 88, PatientId = 88, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 89, PatientId = 89, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 90, PatientId = 90, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 91, PatientId = 91, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 92, PatientId = 92, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 93, PatientId = 93, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 94, PatientId = 94, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 95, PatientId = 95, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 96, PatientId = 96, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 97, PatientId = 97, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 98, PatientId = 98, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 99, PatientId = 99, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 100, PatientId = 100, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 101, PatientId = 101, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 102, PatientId = 102, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 103, PatientId = 103, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 104, PatientId = 104, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 105, PatientId = 105, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 106, PatientId = 106, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 107, PatientId = 107, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 108, PatientId = 108, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 109, PatientId = 109, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 110, PatientId = 110, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 111, PatientId = 111, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 112, PatientId = 112, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 113, PatientId = 113, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 114, PatientId = 114, StatusId = 1, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 115, PatientId = 115, StatusId = 4, PatientStatusDate = DateTime.Parse("2020-03-18") },
                new PatientStatus { PatientStatusId = 116, PatientId = 116, StatusId = 4, PatientStatusDate = DateTime.Parse("2020-03-18") },

                //New Statuses
                new PatientStatus { PatientStatusId = 117, PatientId = 1, StatusId = 3, PatientStatusDate = DateTime.Parse("2020-04-01") },
                new PatientStatus { PatientStatusId = 118, PatientId = 2, StatusId = 3, PatientStatusDate = DateTime.Parse("2020-04-03") },
                new PatientStatus { PatientStatusId = 119, PatientId = 3, StatusId = 3, PatientStatusDate = DateTime.Parse("2020-04-04") },
                new PatientStatus { PatientStatusId = 120, PatientId = 4, StatusId = 2, PatientStatusDate = DateTime.Parse("2020-04-04") },
                new PatientStatus { PatientStatusId = 121, PatientId = 5, StatusId = 3, PatientStatusDate = DateTime.Parse("2020-04-07") },
                new PatientStatus { PatientStatusId = 122, PatientId = 6, StatusId = 2, PatientStatusDate = DateTime.Parse("2020-04-10") },
                new PatientStatus { PatientStatusId = 123, PatientId = 7, StatusId = 2, PatientStatusDate = DateTime.Parse("2020-04-10") },
                new PatientStatus { PatientStatusId = 124, PatientId = 8, StatusId = 3, PatientStatusDate = DateTime.Parse("2020-04-15") },
                new PatientStatus { PatientStatusId = 125, PatientId = 9, StatusId = 3, PatientStatusDate = DateTime.Parse("2020-04-16") },
                new PatientStatus { PatientStatusId = 126, PatientId = 10, StatusId = 3, PatientStatusDate = DateTime.Parse("2020-04-17") });

            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId = 1, PatientAge = 38, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 2, PatientAge = 30, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 3, PatientAge = 38, GenderId = 2, ProvinceId = 4 },
                new Patient { PatientId = 4, PatientAge = 38, GenderId = 2, ProvinceId = 4 },
                new Patient { PatientId = 5, PatientAge = 38, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 6, PatientAge = 45, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 7, PatientAge = 38, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 8, PatientAge = 33, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 9, PatientAge = 34, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 10, PatientAge = 33, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 11, PatientAge = 57, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 12, PatientAge = 40, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 13, PatientAge = 36, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 14, PatientAge = 38, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 15, PatientAge = 27, GenderId = 2, ProvinceId = 6 },
                new Patient { PatientId = 16, PatientAge = 43, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 17, PatientAge = 32, GenderId = 1, ProvinceId = 2 },

                new Patient { PatientId = 18, PatientAge = 39, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 19, PatientAge = 50, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 20, PatientAge = 21, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 21, PatientAge = 57, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 22, PatientAge = 79, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 23, PatientAge = 52, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 24, PatientAge = 50, GenderId = 1, ProvinceId = 9 },

                new Patient { PatientId = 25, PatientAge = 76, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 26, PatientAge = 72, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 27, PatientAge = 47, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 28, PatientAge = 52, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 29, PatientAge = 38, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 30, PatientAge = 62, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 31, PatientAge = 19, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 32, PatientAge = 27, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 33, PatientAge = 33, GenderId = 2, ProvinceId = 9 },
                new Patient { PatientId = 34, PatientAge = 49, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 35, PatientAge = 14, GenderId = 2, ProvinceId = 9 },
                new Patient { PatientId = 36, PatientAge = 73, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 37, PatientAge = 32, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 38, PatientAge = 47, GenderId = 1, ProvinceId = 4 },
                //15 March
                new Patient { PatientId = 39, PatientAge = 60, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 40, PatientAge = 36, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 41, PatientAge = 54, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 42, PatientAge = 27, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 43, PatientAge = 21, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 44, PatientAge = 53, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 45, PatientAge = 29, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 46, PatientAge = 35, GenderId = 2, ProvinceId = 9 },
                new Patient { PatientId = 47, PatientAge = 42, GenderId = 2, ProvinceId = 9 },
                new Patient { PatientId = 48, PatientAge = 50, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 49, PatientAge = 33, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 50, PatientAge = 35, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 51, PatientAge = 34, GenderId = 1, ProvinceId = 4 },

                //16 March
                new Patient { PatientId = 52, PatientAge = 33, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 53, PatientAge = 68, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 54, PatientAge = 30, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 55, PatientAge = 39, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 56, PatientAge = 43, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 57, PatientAge = 50, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 58, PatientAge = 37, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 59, PatientAge = 39, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 60, PatientAge = 15, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 61, PatientAge = 29, GenderId = 1, ProvinceId = 5 },
                new Patient { PatientId = 62, PatientAge = 55, GenderId = 1, ProvinceId = 6 },


                //17 March
                new Patient { PatientId = 63, PatientAge = 45, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 64, PatientAge = 37, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 65, PatientAge = 54, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 66, PatientAge = 52, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 67, PatientAge = 25, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 68, PatientAge = 52, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 69, PatientAge = 59, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 70, PatientAge = 57, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 71, PatientAge = 60, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 72, PatientAge = 37, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 73, PatientAge = 21, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 74, PatientAge = 34, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 75, PatientAge = 26, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 76, PatientAge = 32, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 77, PatientAge = 48, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 78, PatientAge = 59, GenderId = 2, ProvinceId = 4 },
                new Patient { PatientId = 79, PatientAge = 5, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 80, PatientAge = 3, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 81, PatientAge = 3, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 82, PatientAge = 58, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 83, PatientAge = 2, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 84, PatientAge = 62, GenderId = 2, ProvinceId = 9 },
                new Patient { PatientId = 85, PatientAge = 71, GenderId = 2, ProvinceId = 9 },

                //18 March
                new Patient { PatientId = 86, PatientAge = 25, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 87, PatientAge = 45, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 88, PatientAge = 52, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 89, PatientAge = 49, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 90, PatientAge = 35, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 91, PatientAge = 34, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 92, PatientAge = 30, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 93, PatientAge = 36, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 94, PatientAge = 30, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 95, PatientAge = 35, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 96, PatientAge = 34, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 97, PatientAge = 37, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 98, PatientAge = 20, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 99, PatientAge = 3, GenderId = 1, ProvinceId = 3 },
                new Patient { PatientId = 100, PatientAge = 21, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 101, PatientAge = 71, GenderId = 2, ProvinceId = 3 },
                new Patient { PatientId = 102, PatientAge = 59, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 103, PatientAge = 54, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 104, PatientAge = 55, GenderId = 1, ProvinceId = 4 },
                new Patient { PatientId = 105, PatientAge = 64, GenderId = 1, ProvinceId = 6 },
                new Patient { PatientId = 106, PatientAge = 56, GenderId = 2, ProvinceId = 6 },
                new Patient { PatientId = 107, PatientAge = 2, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 108, PatientAge = 51, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 109, PatientAge = 35, GenderId = 2, ProvinceId = 9 },
                new Patient { PatientId = 110, PatientAge = 27, GenderId = 2, ProvinceId = 9 },
                new Patient { PatientId = 111, PatientAge = 60, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 112, PatientAge = 51, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 113, PatientAge = 54, GenderId = 2, ProvinceId = 9 },
                new Patient { PatientId = 114, PatientAge = 51, GenderId = 1, ProvinceId = 9 },
                new Patient { PatientId = 115, PatientAge = 26, GenderId = 2, ProvinceId = 9 },
                new Patient { PatientId = 116, PatientAge = 68, GenderId = 1, ProvinceId = 9 }
           );

            modelBuilder.Entity<Test>().HasData(
                new Test { TestId = 1, PatientId = 1, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-03") },
                new Test { TestId = 2, PatientId = 2, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-07") },

                new Test { TestId = 3, PatientId = 3, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-10") },
                new Test { TestId = 4, PatientId = 4, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-10") },
                new Test { TestId = 5, PatientId = 5, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-10") },
                new Test { TestId = 6, PatientId = 6, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-10") },
                new Test { TestId = 7, PatientId = 7, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-10") },

                new Test { TestId = 8, PatientId = 8, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-11") },
                new Test { TestId = 9, PatientId = 9, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-11") },
                new Test { TestId = 10, PatientId = 10, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-11") },
                new Test { TestId = 11, PatientId = 11, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-11") },
                new Test { TestId = 12, PatientId = 12, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-11") },
                new Test { TestId = 13, PatientId = 13, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-11") },

                new Test { TestId = 14, PatientId = 14, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-12") },
                new Test { TestId = 15, PatientId = 15, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-12") },
                new Test { TestId = 16, PatientId = 16, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-12") },
                new Test { TestId = 17, PatientId = 17, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-12") },

                new Test { TestId = 18, PatientId = 18, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-13") },
                new Test { TestId = 19, PatientId = 19, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-13") },
                new Test { TestId = 20, PatientId = 20, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-13") },
                new Test { TestId = 21, PatientId = 21, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-13") },
                new Test { TestId = 22, PatientId = 22, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-13") },
                new Test { TestId = 23, PatientId = 23, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-13") },
                new Test { TestId = 24, PatientId = 24, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-13") },

                new Test { TestId = 25, PatientId = 25, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 26, PatientId = 26, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 27, PatientId = 27, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 28, PatientId = 28, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 29, PatientId = 29, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 30, PatientId = 30, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 31, PatientId = 31, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 32, PatientId = 32, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 33, PatientId = 33, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 34, PatientId = 34, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 35, PatientId = 35, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 36, PatientId = 36, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 37, PatientId = 37, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },
                new Test { TestId = 38, PatientId = 38, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-14") },

                new Test { TestId = 39, PatientId = 39, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },
                new Test { TestId = 40, PatientId = 40, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },
                new Test { TestId = 41, PatientId = 41, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },
                new Test { TestId = 42, PatientId = 42, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },
                new Test { TestId = 43, PatientId = 43, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },
                new Test { TestId = 44, PatientId = 44, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },
                new Test { TestId = 45, PatientId = 45, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },
                new Test { TestId = 46, PatientId = 46, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },
                new Test { TestId = 47, PatientId = 47, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },
                new Test { TestId = 48, PatientId = 48, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },
                new Test { TestId = 49, PatientId = 49, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },
                new Test { TestId = 50, PatientId = 50, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },
                new Test { TestId = 51, PatientId = 51, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-15") },

                new Test { TestId = 52, PatientId = 52, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-16") },
                new Test { TestId = 53, PatientId = 53, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-16") },
                new Test { TestId = 54, PatientId = 54, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-16") },
                new Test { TestId = 55, PatientId = 55, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-16") },
                new Test { TestId = 56, PatientId = 56, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-16") },
                new Test { TestId = 57, PatientId = 57, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-16") },
                new Test { TestId = 58, PatientId = 58, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-16") },
                new Test { TestId = 59, PatientId = 59, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-16") },
                new Test { TestId = 60, PatientId = 60, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-16") },
                new Test { TestId = 61, PatientId = 61, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-16") },
                new Test { TestId = 62, PatientId = 62, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-16") },

                new Test { TestId = 63, PatientId = 63, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 64, PatientId = 64, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 65, PatientId = 65, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 66, PatientId = 66, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 67, PatientId = 67, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 68, PatientId = 68, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 69, PatientId = 69, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 70, PatientId = 70, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 71, PatientId = 71, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 72, PatientId = 72, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 73, PatientId = 73, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 74, PatientId = 74, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 75, PatientId = 75, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 76, PatientId = 76, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 77, PatientId = 77, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 78, PatientId = 78, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 79, PatientId = 79, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 80, PatientId = 80, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 81, PatientId = 81, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 82, PatientId = 82, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 83, PatientId = 83, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 84, PatientId = 84, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },
                new Test { TestId = 85, PatientId = 85, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-17") },

                new Test { TestId = 86, PatientId = 86, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 87, PatientId = 87, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 88, PatientId = 88, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 89, PatientId = 89, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 90, PatientId = 90, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 91, PatientId = 91, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 92, PatientId = 92, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 93, PatientId = 93, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 94, PatientId = 94, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 95, PatientId = 95, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 96, PatientId = 96, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 97, PatientId = 97, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 98, PatientId = 98, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 99, PatientId = 99, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 100, PatientId = 100, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 101, PatientId = 101, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 102, PatientId = 102, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 103, PatientId = 103, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 104, PatientId = 104, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 105, PatientId = 105, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 106, PatientId = 106, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 107, PatientId = 107, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 108, PatientId = 108, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 109, PatientId = 109, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 110, PatientId = 110, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 111, PatientId = 111, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 112, PatientId = 112, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 113, PatientId = 113, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 114, PatientId = 114, LabId = 1, TestResultId = 1, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 115, PatientId = 115, LabId = 1, TestResultId = 2, TestDate = DateTime.Parse("2020-03-18") },
                new Test { TestId = 116, PatientId = 116, LabId = 1, TestResultId = 2, TestDate = DateTime.Parse("2020-03-18") },

                //New Tests
                new Test { TestId = 117, PatientId = 1, LabId = 1, TestResultId = 2, TestDate = DateTime.Parse("2020-04-01") },
                new Test { TestId = 118, PatientId = 2, LabId = 2, TestResultId = 2, TestDate = DateTime.Parse("2020-04-03") },
                new Test { TestId = 119, PatientId = 3, LabId = 2, TestResultId = 2, TestDate = DateTime.Parse("2020-04-04") },
                new Test { TestId = 120, PatientId = 5, LabId = 2, TestResultId = 2, TestDate = DateTime.Parse("2020-04-07") },
                new Test { TestId = 121, PatientId = 8, LabId = 1, TestResultId = 2, TestDate = DateTime.Parse("2020-04-15") },
                new Test { TestId = 122, PatientId = 9, LabId = 1, TestResultId = 2, TestDate = DateTime.Parse("2020-04-16") },
                new Test { TestId = 123, PatientId = 10, LabId = 2, TestResultId = 2, TestDate = DateTime.Parse("2020-04-17") }
                );
        }
    }
}
