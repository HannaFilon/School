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

        Task<CourseDto> CreateCourse(CourseModel courseModel, Guid teacherId);

        Task<CourseDto> UpdateCourse(CourseModel courseModel);
        Task ChangeCourseTeacher(Guid courseId, Guid teacherId);

        Task DeleteCourse(Guid courseId);
    }
}
