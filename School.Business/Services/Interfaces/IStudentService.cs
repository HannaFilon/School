using School.Business.ModelsDto;
using System;
using System.Threading.Tasks;

namespace School.Business.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> GetStudent(Guid studentId);

        Task<StudentDto> CreateStudent(StudentModel studentModel);

        Task<StudentDto> UpdateStudent(StudentModel studentModel);
        Task EnrollStudent(Guid studentId, Guid courseId);

        Task DeleteStudent(Guid studentId);
        
    }
}
