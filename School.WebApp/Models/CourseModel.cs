using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsActivated { get; set; }
        public override string ToString() => Title;
    }
}
