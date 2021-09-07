using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.WebApp.Models
{
    public class AssignedCourseData
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}
