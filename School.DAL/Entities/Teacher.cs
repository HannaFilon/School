using System.Collections.Generic;

namespace School.DAL.Entities
{
    public sealed class Teacher: Person
    {
        public List<Course> Courses = new List<Course>();

    }
}
