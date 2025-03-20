using efcoreApp.Data;
using efcoreApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace efcoreApp.Controllers
{
    public class CourseController(DataDbContext context) : Controller
    {
        private readonly DataDbContext _context = context;
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Courses.ToListAsync());
        }

        public async Task<IActionResult> Create(Course course)
        {
            if (course == null)
            {
                return BadRequest();
            }
            try
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return RedirectToAction("Index");
        }
    }
}
