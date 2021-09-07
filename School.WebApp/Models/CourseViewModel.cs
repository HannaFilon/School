using System;
using System.ComponentModel.DataAnnotations;

namespace School.WebApp.Models
{
    public class CourseViewModel
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }
        [Required]
        public bool IsActivated { get; set; }
        public string TeachersId { get; set; }
        public string TeachersFullName { get; set; }
        public override string ToString() => Title;
    }
}
