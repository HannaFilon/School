using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace School.WebApp.Models
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        public Dictionary<Guid, string> AssignedCourses { get; set; } = new Dictionary<Guid, string>(); 
    }
}
