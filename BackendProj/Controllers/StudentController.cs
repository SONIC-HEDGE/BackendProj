using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendProj.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProj.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext _context;

        public StudentController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard(int id)
        {
            var student = await _context.Students
                .Include(s => s.Subjects)
                .ThenInclude(sub => sub.Grades)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}