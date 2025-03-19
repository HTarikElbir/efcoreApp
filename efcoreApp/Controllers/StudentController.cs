using efcoreApp.Data;
using efcoreApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class StudentController(DataDbContext context) : Controller
    {
        private readonly DataDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Students.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
           
            return RedirectToAction("Index");
        }
    }
}
