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
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TeacherDto> GetTeacher(Guid teacherId)
        {
            var teacher = await _unitOfWork.TeacherRepository.Get()
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.Id == teacherId);
            if (teacher == null)
            {
                throw new Exception("Teacher not found.");
            }

            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            return teacherDto;
        }

        public async Task<TeacherDto> CreateTeacher(TeacherModel teacherModel)
        {
            var teacher = _mapper.Map<Teacher>(teacherModel);
            await _unitOfWork.TeacherRepository.Add(teacher);
            await _unitOfWork.SaveChanges();
            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            return teacherDto;
        }

        public async Task<TeacherDto> UpdateTeacher(TeacherModel teacherModel)
        {
            var teacher = await _unitOfWork.StudentRepository.GetById(teacherModel.Id);
            if (teacher == null)
            {
                throw new Exception("Teacher not found.");
            }

            _mapper.Map(teacherModel, teacher);
            await _unitOfWork.TeacherRepository.Update(teacher);
            await _unitOfWork.SaveChanges();
            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            return teacherDto;
        }

        public async Task AddCourseToTeacher(Guid teacherId, Guid courseId)
        {
            var teacher = await _unitOfWork.TeacherRepository.Get()
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.Id == teacherId);
            if (teacher == null)
            {
                throw new Exception("Teacher not found.");
            }

            var course = await _unitOfWork.CourseRepository.GetById(courseId);
            if (course == null)
            {
                throw new Exception("Course not found.");
            }

            teacher.Courses.Add(course);
            _unitOfWork.TeacherRepository.Update(teacher);
            await _unitOfWork.SaveChanges();
        }

        public Task DeleteTeacher(Guid teacherId)
        {
            
        }
    }
}
