using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Routine.Api.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Introduction { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}