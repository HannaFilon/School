using School.Business.ModelsDto;
using System;
using System.Threading.Tasks;

namespace School.Business.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> GetStudent(Guid studentId);

        Task<StudentDto> AddStudent(StudentDto studentDto);

        Task<StudentDto> UpdateStudent(StudentDto studentDto);
        Task EnrollStudent(Guid studentId, Guid courseId);

        Task DeleteStudent(Guid studentId);
        
    }
}
