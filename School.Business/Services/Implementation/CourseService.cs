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
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CourseDto> CreateCourse(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            course.IsActivated = false;
            await _unitOfWork.CourseRepository.Add(course);
            await _unitOfWork.SaveChanges();
            _mapper.Map(course, courseDto);

            return courseDto;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            var courses = await _unitOfWork.CourseRepository.GetAll();
            var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(courses);

            return coursesDto;
        }

        public async Task<CourseDto> GetCourse(Guid courseId)
        {
            var course = await _unitOfWork.CourseRepository.Get()
                .Include(c => c.CourseStudents)
                .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null)
            {
                throw new Exception("Course not found.");
            }

            var courseDto = _mapper.Map<CourseDto>(course);

            return courseDto;
        }

        public async Task<CourseDto> UpdateCourse(CourseDto courseDto)
        {
            var course = await _unitOfWork.CourseRepository.GetById(courseDto.Id);
            if (course == null)
            {
                throw new Exception("Course not found.");
            }
            _mapper.Map(courseDto, course);

            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveChanges();
            _mapper.Map(course, courseDto);

            return courseDto;
        }

        public async Task ChangeCourseTeacher(Guid courseId, Guid teacherId)
        {
            var course = await _unitOfWork.CourseRepository.GetById(courseId);
            if (course == null)
            {
                throw new Exception("Course not found.");
            }

            var teacher = await _unitOfWork.TeacherRepository.GetById(teacherId);
            if (teacher == null)
            {
                throw new Exception("Teacher not found.");
            }

            course.Teacher = teacher;
            course.TeacherId = teacher.Id;
            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteCourse(Guid courseId)
        {
            var course = await _unitOfWork.CourseRepository.GetById(courseId);
            if (course == null)
            {
                throw new Exception("Course not found.");
            }

            _unitOfWork.CourseRepository.Remove(course);
            await _unitOfWork.SaveChanges();
        }
    }
}
