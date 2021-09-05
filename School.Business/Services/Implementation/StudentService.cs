using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School.Business.ModelsDto;
using School.Business.Services.Interfaces;
using School.DAL.Entities;
using School.DAL.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace School.Business.Services.Implementation
{
    public class StudentService: IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StudentDto> GetStudent(Guid studentId)
        {
            var student = await _unitOfWork.StudentRepository.Get()
                .Include(s => s.CourseStudents)
                .FirstOrDefaultAsync(s => s.Id == studentId);
            if (student == null)
            {
                throw new Exception("Student not found.");
            }

            var studentDto = _mapper.Map<StudentDto>(student);

            return studentDto;
        }

        public async Task<StudentDto> CreateStudent(StudentModel studentModel)
        {
            var student = _mapper.Map<Student>(studentModel);
            await _unitOfWork.StudentRepository.Add(student);
            await _unitOfWork.SaveChanges();
            var studentDto = _mapper.Map<StudentDto>(student);

            return studentDto;
        }

        public async Task<StudentDto> UpdateStudent(StudentModel studentModel)
        {
            var student = await _unitOfWork.StudentRepository.GetById(studentModel.Id);
            if (student == null)
            {
                throw new Exception("Student not found.");
            }

            _mapper.Map(studentModel, student);
            await _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.SaveChanges();
            var studentDto = _mapper.Map<StudentDto>(student);

            return studentDto;
        }

        public async Task EnrollStudent(Guid studentId, Guid courseId)
        {
            var student = await _unitOfWork.StudentRepository.Get()
                .Include(s => s.CourseStudents)
                .FirstOrDefaultAsync(s => s.Id == studentId);
            if (student == null)
            {
                throw new Exception("Student not found.");
            }

            var course = await _unitOfWork.CourseRepository.GetById(courseId);
            if (course == null)
            {
                throw new Exception("Course not found.");
            }

            var courseStudent = new CourseStudent()
            {
                Student = student,
                StudentId = student.Id,
                Course = course,
                CourseId = course.Id,
            };

            student.CourseStudents.Add(courseStudent);
            _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteStudent(Guid studentId)
        {
            var student = _unitOfWork.StudentRepository.GetById(studentId);
            if (student == null)
            {
                throw new Exception("Student not found.");
            }

            await _unitOfWork.StudentRepository.Remove(studentId);
        }
    }
}
