using System.Collections.Generic;

namespace School.DAL.Entities
{
    public sealed class Teacher: Person
    {
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
