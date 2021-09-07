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
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherService teacherService, ICourseService courseService, IMapper mapper)
        {
            _teacherService = teacherService;
            _courseService = courseService;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var teachersDto = await _teacherService.GetAllTeachers();
            if (teachersDto == null)
            {
                return NotFound("No courses found.");
            }

            var teacherViewModels = _mapper.Map<List<PersonViewModel>>(teachersDto);

            return View(teacherViewModels);
        }

        public async Task<ActionResult> Info(Guid? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            var teacherDto = await _teacherService.GetTeacher(Id.Value);
            var teacherViewModel = _mapper.Map<PersonViewModel>(teacherDto);
            foreach (var course in teacherDto.Courses)
            {
                teacherViewModel.AssignedCourses.Add(course.Id, course.Title);
            }

            return View(teacherViewModel);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(PersonViewModel teacherViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var teacherDto = _mapper.Map<TeacherDto>(teacherViewModel);
            teacherDto = await _teacherService.AddTeacher(teacherDto);

            return RedirectToAction("Info",new { Id = teacherDto.Id});
        }

        public async Task<ActionResult> Edit(Guid? Id)
        {
            if (!Id.HasValue)
            {
                return NotFound();
            }

            var teacherDto = await _teacherService.GetTeacher(Id.Value);
            if (teacherDto == null)
            {
                return NotFound();
            }

            var teacherViewModel = _mapper.Map<PersonViewModel>(teacherDto);
            await PopulateAssignedCourseData(teacherDto);

            return View(teacherViewModel);
        }

        private async Task PopulateAssignedCourseData(TeacherDto teacherDto)
        {
            var allCourses = await _courseService.GetAllCourses();
            var teacherCourses = new HashSet<Guid>();
            foreach (var course in teacherDto.Courses)
            {
                teacherCourses.Add(course.Id);
            }

            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseId = course.Id,
                    Title = course.Title,
                    Assigned = teacherCourses.Contains(course.Id)
                });
            }

            ViewBag.Courses = viewModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid Id, [Bind("Id,FullName,DateOfBirth,Address")] PersonViewModel teacherViewModel, string[] selectedCourses)
        {
            if (Id != teacherViewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(teacherViewModel);
            }

            var teacherDto = await _teacherService.GetTeacher(Id);
            if (teacherViewModel.FullName != null && teacherViewModel.FullName != teacherDto.FullName ||
                teacherViewModel.DateOfBirth != default && teacherViewModel.DateOfBirth != teacherDto.DateOfBirth ||
                teacherViewModel.Address != null && teacherViewModel.Address != teacherDto.Address)
            {
                _mapper.Map(teacherViewModel, teacherDto);
            }

            await UpdateTeacherCourses(selectedCourses, teacherDto);
            await _teacherService.UpdateTeacher(teacherDto);
            await PopulateAssignedCourseData(teacherDto);

            return RedirectToAction("Info", new { Id = Id });
        }

        private async Task UpdateTeacherCourses(string[] selectedCourses, TeacherDto teacherDto)
        {
            if (selectedCourses == null)
            {
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var teacherCoursesHS = new HashSet<Guid>();
            foreach (var course in teacherDto.Courses)
            {
                teacherCoursesHS.Add(course.Id);
            }

            var allCourses = await _courseService.GetAllCourses();
            foreach (var course in allCourses)
            {
                if (selectedCoursesHS.Contains(course.Id.ToString()))
                {
                    if (!teacherCoursesHS.Contains(course.Id))
                    {
                        teacherDto.Courses.Add(course);
                    }
                }
                else
                {
                    if (teacherCoursesHS.Contains(course.Id))
                    {
                        teacherDto.Courses.Remove(course);
                    }
                }
            }
        }

        public async Task<ActionResult> Delete(Guid? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            var teacherDto = await _teacherService.GetTeacher(Id.Value);
            if (teacherDto == null)
            {
                return NotFound();
            }

            var teacherViewModel = _mapper.Map<PersonViewModel>(teacherDto);
            return View(teacherViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid Id)
        {
            await _teacherService.DeleteTeacher(Id);

            return RedirectToAction("Index", "Courses");
        }
    }
}
