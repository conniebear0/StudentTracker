using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentTracker.Models;
using StudentTracker.Services;
namespace StudentTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentDbContext _context;

        public HomeController(ILogger<HomeController> logger, StudentDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Students()
        {
            var allStudents = _context.Students.ToList();
            return View(allStudents);
        }

        public IActionResult CreateEditStudentForm(Student model)
        {

            if(model.StudentID == 0)
            {
                _context.Students.Add(model);
            }
            else
            {
                _context.Students.Update(model);
            }
            _context.SaveChanges();
            return RedirectToAction("Students");
        }
        public IActionResult CreateEditStudent(int? id)
        {
            if (id != 0)
            {
                var studentInDb = _context.Students.FirstOrDefault(x => x.StudentID == id);
                return View(studentInDb);
            }
            return View();
        }

        public IActionResult DeleteStudent(int id)
        {
            var studentInDb = _context.Students.FirstOrDefault(x => x.StudentID == id);

            _context.Students.Remove(studentInDb);
            _context.SaveChanges();
            return RedirectToAction("Students");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
