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

        public async Task<IActionResult> Info(Guid courseId)
        {
            var courseDto = await _courseService.GetCourse(courseId);

            return View(courseDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseModel courseModel)
        {
            if (courseModel == null)
            {
                return View("Bad Request");
            }
            var courseDto = _mapper.Map<CourseDto>(courseModel);
            courseDto = await _courseService.CreateCourse(courseDto);

            return View(courseDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CourseModel courseModel) 
        {
            if (courseModel == null)
            {
                return View("Bad Request");
            }
            var courseDto = _mapper.Map<CourseDto>(courseModel);
            courseDto = await _courseService.UpdateCourse(courseDto);

            return View(courseDto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid courseId) 
        {
            await _courseService.DeleteCourse(courseId);

            return View();
        }
    }
}
