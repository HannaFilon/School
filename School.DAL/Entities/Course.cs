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
        [StringLength(800)]
        public string Title { get; set; }
        [Required]
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        [Required]
        public bool IsActivated { get; set; }
        public List<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
    }
}
