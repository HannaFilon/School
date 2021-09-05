using School.Business.ModelsDto;
using System;
using System.Threading.Tasks;

namespace School.Business.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherDto> GetTeacher(Guid teacherId);

        Task<TeacherDto> CreateTeacher(TeacherModel teacherModel);

        Task<TeacherDto> UpdateTeacher(TeacherModel teacherModel);
        Task AddCourseToTeacher(Guid teacherId, Guid courseId);

        Task DeleteTeacher(Guid teacherId);
       
    }
}
