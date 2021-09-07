using School.Business.ModelsDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Business.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherDto> GetTeacher(Guid teacherId);
        Task<IEnumerable<TeacherDto>> GetAllTeachers();

        Task<TeacherDto> AddTeacher(TeacherDto teacherDto);

        Task<TeacherDto> UpdateTeacher(TeacherDto teacherDto);
        Task AddCourseToTeacher(Guid teacherId, Guid courseId);
        Task RemoveCourseFromTeacher(Guid teacherId, Guid courseId);

        Task DeleteTeacher(Guid teacherId);
       
    }
}
