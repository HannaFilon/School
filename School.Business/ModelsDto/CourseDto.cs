using System;
using System.Collections.Generic;

namespace School.Business.ModelsDto
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public TeacherDto Teacher { get; set; }
        public bool IsActivated { get; set; }

        public List<CourseStudentDto> CourseStudents { get; set; } = new List<CourseStudentDto>();
    }
}
