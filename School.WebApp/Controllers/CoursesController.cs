using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Business.ModelsDto;
using School.Business.Services.Interfaces;
using School.WebApp.Models;
using System;
using System.Threading.Tasks;

namespace School.WebApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        public async Task<IActionResult> CourseInfo(Guid courseId)
        {
            var courseDto = await _courseService.GetCourse(courseId);

            return View(courseDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseModel courseModel)
        {
            if (courseModel == null)
            {
                return View("Bad Request");
            }
            var courseDto = _mapper.Map<CourseDto>(courseModel);
            courseDto = await _courseService.CreateCourse(courseDto);

            return View(courseDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse(CourseModel courseModel) 
        {
            if (courseModel == null)
            {
                return View("Bad Request");
            }
            var courseDto = _mapper.Map<CourseDto>(courseModel);
            courseDto = await _courseService.UpdateCourse(courseDto);

            return View(courseDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(Guid courseId) 
        {
            await _courseService.DeleteCourse(courseId);

            return View();
        }
    }
}
