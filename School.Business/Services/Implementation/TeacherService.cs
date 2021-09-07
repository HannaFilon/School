using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School.Business.ModelsDto;
using School.Business.Services.Interfaces;
using School.DAL.Entities;
using School.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<TeacherDto>> GetAllTeachers()
        {
            var teachers = await _unitOfWork.TeacherRepository.GetAll();
            var teachersDto = _mapper.Map<IEnumerable<TeacherDto>>(teachers);

            return teachersDto;
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

        public async Task<TeacherDto> AddTeacher(TeacherDto teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);
            teacher.Id = Guid.NewGuid();
            await _unitOfWork.TeacherRepository.Add(teacher);
            await _unitOfWork.SaveChanges();
            _mapper.Map(teacher, teacherDto);

            return teacherDto;
        }

        public async Task<TeacherDto> UpdateTeacher(TeacherDto teacherDto)
        {
            var teacher = await _unitOfWork.TeacherRepository.GetById(teacherDto.Id);
            if (teacher == null)
            {
                throw new Exception("Teacher not found.");
            }

            _mapper.Map(teacherDto, teacher);
            teacher.Courses = _mapper.Map<List<Course>>(teacherDto.Courses);
            _unitOfWork.TeacherRepository.Update(teacher);
            await _unitOfWork.SaveChanges();
            _mapper.Map(teacher, teacherDto);

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

        public async Task RemoveCourseFromTeacher(Guid teacherId, Guid courseId)
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

            teacher.Courses.Remove(course);
            _unitOfWork.TeacherRepository.Update(teacher);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteTeacher(Guid teacherId)
        {
            var teacher = _unitOfWork.TeacherRepository.GetById(teacherId);
            if (teacher == null)
            {
                throw new Exception("Teacher not found.");
            }

            await _unitOfWork.TeacherRepository.Remove(teacherId);
        }
    }
}
