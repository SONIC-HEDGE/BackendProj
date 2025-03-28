using BackendProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendProj.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SchoolContext _context;

        public TeacherController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet("/teacher/{id}")]
        public IActionResult Dashboard(int id)
        {
            var teacher = _context.Teachers
                .Include(t => t.Subjects)
                .ThenInclude(s => s.Grades)
                .ThenInclude(g => g.Student)
                .FirstOrDefault(t => t.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }
    }
}