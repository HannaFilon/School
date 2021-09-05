using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.Entities
{
    public sealed class Student: Person
    {
        public List<CourseStudent> CourseStudents = new List<CourseStudent>();
    }
}
