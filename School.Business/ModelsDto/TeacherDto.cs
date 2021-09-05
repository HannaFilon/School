using System.Collections.Generic;

namespace School.Business.ModelsDto
{
    public class TeacherDto: PersonDto
    {
        public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
    }
}
