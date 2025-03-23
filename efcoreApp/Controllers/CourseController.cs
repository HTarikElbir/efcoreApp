using efcoreApp.Data;
using efcoreApp.Models.Entities;
using efcoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace efcoreApp.Controllers
{
    public class CourseController(DataDbContext context) : Controller
    {
        private readonly DataDbContext _context = context;
        public async Task<IActionResult> Index()
        {

            return View(await _context.Courses.Include(t => t.Teacher).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "TeacherId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel course)
        {
            if (course == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Courses.Add(new Course { Id = course.Id, Name = course.Name, TeacherId = course.TeacherId });
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                return RedirectToAction("Index");
            }
            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "TeacherId", "FullName");

            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var course = await _context
                .Courses
                .Include(c => c.CourseRegistrations)    
                .ThenInclude(s => s.Student)
                .Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    TeacherId = c.TeacherId,
                    CourseRegistrations = c.CourseRegistrations
                })
                .FirstOrDefaultAsync(c => c.Id == id);

            
            if (course == null)
            {
                return NotFound();
            }
            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "TeacherId", "FullName");

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseViewModel course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Courses.Update(new Course { Id = course.Id, Name=course.Name, TeacherId=course.TeacherId });
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Courses.Any(c => c.Id == course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewBag.Teachers = new SelectList(await _context.Teachers.ToListAsync(), "TeacherId", "FullName");

            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
