using System.Collections.Generic;

namespace School.DAL.Entities
{
    public sealed class Student: Person
    {
        public List<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
    }
}
