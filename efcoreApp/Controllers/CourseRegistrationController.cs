using efcoreApp.Data;
using efcoreApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace efcoreApp.Controllers
{
    public class CourseRegistrationController(DataDbContext context) : Controller
    {
        public readonly DataDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            return View(await _context
                             .CourseRegistrations
                             .Include(s => s.Student)
                             .Include(c => c.Course)
                             .ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Students = new SelectList(await _context.Students.ToListAsync(),"Id","FullName");
            ViewBag.Courses = new SelectList(await _context.Courses.ToListAsync(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseRegistration courseRegistration)
        {
            courseRegistration.RegistrationDate = DateTime.Now;
            _context.CourseRegistrations.Add(courseRegistration);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
