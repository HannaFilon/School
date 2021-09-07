using Microsoft.AspNetCore.Mvc;

namespace School.WebApp.Controllers
{
    public class StudentsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
