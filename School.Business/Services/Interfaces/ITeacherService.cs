using School.Business.ModelsDto;
using System;
using System.Threading.Tasks;

namespace School.Business.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherDto> GetTeacher(Guid teacherId);

        Task<TeacherDto> CreateTeacher(TeacherDto teacherDto);

        Task<TeacherDto> UpdateTeacher(TeacherDto teacherDto);
        Task AddCourseToTeacher(Guid teacherId, Guid courseId);

        Task DeleteTeacher(Guid teacherId);
       
    }
}
