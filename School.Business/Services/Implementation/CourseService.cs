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

        public async Task<CourseDto> CreateCourse(CourseModel courseModel, Guid teacherId)
        {
            var course = _mapper.Map<Course>(courseModel);
            await _unitOfWork.CourseRepository.Add(courseModel);
            await _unitOfWork.SaveChanges();
            var courseDto = _mapper.Map<CourseDto>(course);

            return courseDto;
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

        public async Task<CourseDto> UpdateCourse(CourseModel courseModel, Guid? teacherId)
        {
            var course = await _unitOfWork.CourseRepository.GetById(courseModel.Id);
            if (course == null)
            {
                throw new Exception("Course not found.");
            }
            _mapper.Map(courseModel, course);

            await _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveChanges();
            var courseDto = _mapper.Map<CourseDto>(course);

            return courseDto;
        }

        public Task<CourseDto> UpdateCourse(CourseModel courseModel)
        {
            throw new NotImplementedException();
        }

        public Task ChangeCourseTeacher(Guid courseId, Guid teacherId)
        {
            throw new NotImplementedException();
        }
    }
}
