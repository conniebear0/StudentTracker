using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Students()
        {
            var allStudents = await _context.Students.ToListAsync();
            return View(allStudents);
        }

        public async Task<IActionResult> CreateEditStudentForm(Student model)
        {

            if(model.StudentID == 0)
            {
                await _context.Students.AddAsync(model);
            }
            else
            {
                _context.Students.Update(model);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Students");
        }
        public async Task<IActionResult> CreateEditStudent(int? id)
        {
            if (id != 0)
            {
                var studentInDb = await _context.Students.FirstOrDefaultAsync(x => x.StudentID == id);
                return View(studentInDb);
            }
            return View();
        }

        public async Task<IActionResult> DeleteStudent(int id)
        {
            var studentInDb = await _context.Students.FirstOrDefaultAsync(x => x.StudentID == id);

            _context.Students.Remove(studentInDb);
            await _context.SaveChangesAsync();
            return RedirectToAction("Students");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
