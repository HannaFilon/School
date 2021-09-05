using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.DAL.Entities
{
    [Index(nameof(Title), IsUnique = true)]
    public sealed class Course
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Range(typeof(int), "0", "??")]
        public int Amount { get; set; }

        public List<CourseStudent> CourseStudents = new List<CourseStudent>();
    }
}
