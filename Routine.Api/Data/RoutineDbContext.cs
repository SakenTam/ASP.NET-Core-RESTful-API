using System;
using Microsoft.EntityFrameworkCore;
using Routine.Api.Entities;

namespace Routine.Api.Data
{
    public class RoutineDbContext : DbContext
    {
        public RoutineDbContext(DbContextOptions<RoutineDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>().HasData(
                new Company()
                {
                    Id = Guid.Parse("4AEE42BD-0109-4F17-AF5C-77CF9F536341"),
                    Name = "Microsoft",
                    Introduction = "Great Company"
                }, new Company()
                {
                    Id = Guid.Parse("C667B0F9-3B04-40E4-A4B1-06557516A517"),
                    Name = "Google",
                    Introduction = "No Evil Company"
                }, new Company()
                {
                    Id = Guid.Parse("F3D915EE-689E-4A6D-B20B-B4DA28AE2EA2"),
                    Name = "Alipapa",
                    Introduction = "Fubao Company"
                }

            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = Guid.Parse("12894822-D70F-4B56-A192-6BBB03F5D095"),
                    CompanyId = Guid.Parse("4AEE42BD-0109-4F17-AF5C-77CF9F536341"),
                    DateOfBirth = new DateTime(1999, 03, 16),
                    EmployeeNo = "MSFT01",
                    FirstName = "Saken",
                    LastName = "Tam",
                    Gender = Gender.男,
                },
                new Employee()
                {
                    Id = Guid.Parse("2146BF8E-DF32-421F-9AB6-452B444D0EDC"),
                    CompanyId = Guid.Parse("C667B0F9-3B04-40E4-A4B1-06557516A517"),
                    DateOfBirth = new DateTime(1998, 4, 16),
                    EmployeeNo = "GG01",
                    FirstName = "Nick",
                    LastName = "Young",
                    Gender = Gender.男,
                },
                new Employee()
                {
                    Id = Guid.Parse("9EBFE079-A4EC-4047-B434-6EB37A9FCB4C"),
                    CompanyId = Guid.Parse("F3D915EE-689E-4A6D-B20B-B4DA28AE2EA2"),
                    DateOfBirth = new DateTime(1997, 7, 15),
                    EmployeeNo = "ALPP01",
                    FirstName = "Yougtee",
                    LastName = "Tam",
                    Gender = Gender.男,
                },
                new Employee()
                {
                    Id = Guid.Parse("7017439B-A357-404C-A831-65C0F4985AF8"),
                    CompanyId = Guid.Parse("4AEE42BD-0109-4F17-AF5C-77CF9F536341"),
                    DateOfBirth = new DateTime(1993, 5, 15),
                    EmployeeNo = "MSFT02",
                    FirstName = "Sara",
                    LastName = "Wong",
                    Gender = Gender.男,
                });
        }
    }
}