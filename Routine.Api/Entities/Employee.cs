using System;
using System.ComponentModel.DataAnnotations;

namespace Routine.Api.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }

        [MaxLength(10)]
        public string EmployeeNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public Company Company { get; set; }

    }
}