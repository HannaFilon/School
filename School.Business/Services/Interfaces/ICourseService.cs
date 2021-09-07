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

        Task<CourseDto> AddCourse(CourseDto courseDto);

        Task<CourseDto> UpdateCourse(CourseDto courseDto);

        Task DeleteCourse(Guid courseId);
    }
}
