using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myExamination.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Birthdate { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public string Brgy { get; set; }

    }
}