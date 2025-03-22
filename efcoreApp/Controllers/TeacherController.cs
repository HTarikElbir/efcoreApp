using efcoreApp.Data;
using efcoreApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class TeacherController(DataDbContext context) : Controller
    {

        private readonly DataDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            return View(await _context.Teachers.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (teacher == null)
            {
                return BadRequest();
            }
            teacher.StartDate = DateTime.Now;

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var teacher = await _context
                .Teachers
                .FirstOrDefaultAsync(t => t.TeacherId == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return BadRequest();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Teachers.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Teachers.Any(t => t.TeacherId == teacher.TeacherId))
                    {
                        return NotFound();
                    }
                    else
                        throw;
                }

                return RedirectToAction("Index");
            }
            return View(teacher);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
