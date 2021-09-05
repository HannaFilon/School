using Microsoft.AspNetCore.Mvc;
using School.Business.Services.Interfaces;

namespace School.WebApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService) 
        {
            _courseService = courseService;
        }
        /*
        [HttpGet]
        public async Task<IActionResult> ()
        {
            return View();
        }*/
    }
}
