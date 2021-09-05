using School.Business.ModelsDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Business.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDto> GetCourse(Guid courseId);
        Task<IEnumerable<CourseDto>> GetAllCourses();

        Task<CourseDto> CreateCourse(CourseDto courseDto);

        Task<CourseDto> UpdateCourse(CourseDto courseDto);
        Task ChangeCourseTeacher(Guid courseId, Guid teacherId);

        Task DeleteCourse(Guid courseId);
    }
}
