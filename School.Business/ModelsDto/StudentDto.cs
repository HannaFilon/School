using System.Collections.Generic;

namespace School.Business.ModelsDto
{
    public class StudentDto: PersonDto
    {
        public List<CourseStudentDto> CourseStudents { get; set; } = new List<CourseStudentDto>();
    }
}
