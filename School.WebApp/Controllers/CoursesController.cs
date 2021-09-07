using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Business.ModelsDto;
using School.Business.Services.Interfaces;
using School.WebApp.Models;
using System;
using System.Collections.Generic;
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

        public async Task<ActionResult> Index()
        {
            var coursesDto = await _courseService.GetAllCourses();
            if (coursesDto == null)
            {
                return NotFound("No courses found.");
            }

            var courseViewModels = _mapper.Map<List<CourseViewModel>>(coursesDto);

            return View(courseViewModels);
        }

        public async Task<ActionResult> Info(Guid? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            var courseDto = await _courseService.GetCourse(Id.Value);
            var courseViewModel = _mapper.Map<CourseViewModel>(courseDto);

            return View(courseViewModel);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(CourseViewModel courseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var courseDto = _mapper.Map<CourseDto>(courseViewModel);
            courseDto = await _courseService.AddCourse(courseDto);

            return RedirectToAction("Info", new { Id = courseDto.Id });
        }

        public async Task<ActionResult> Edit(Guid? Id)
        {
            if (!Id.HasValue)
            {
                return NotFound();
            }

            var courseDto = await _courseService.GetCourse(Id.Value);
            if (courseDto == null)
            {
                return NotFound();
            }

            var editCourseViewModel = _mapper.Map<CourseViewModel>(courseDto);

            return View(editCourseViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Guid Id, [Bind("Id,Title")] CourseViewModel courseViewModel)
        {
            if (Id != courseViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(courseViewModel);
            }

            var courseDto = await _courseService.GetCourse(Id);
            if (courseViewModel.Title != courseDto.Title)
            {
                _mapper.Map(courseViewModel, courseDto);
                await _courseService.UpdateCourse(courseDto);
            }

            return RedirectToAction("Info", new { Id = Id });
        }

        public async Task<ActionResult> Delete(Guid? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            var courseDto = await _courseService.GetCourse(Id.Value);
            if (courseDto == null)
            {
                return NotFound();
            }

            var courseViewModel = _mapper.Map<CourseViewModel>(courseDto);

            return View(courseViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid Id)
        {
            await _courseService.DeleteCourse(Id);

            return RedirectToAction("Index");
        }
    }
}
