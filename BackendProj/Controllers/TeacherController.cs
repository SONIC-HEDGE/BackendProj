using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendProj.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProj.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SchoolContext _context;

        public TeacherController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            var teacher = await _context.Teachers
                .Include(t => t.Subjects)
                .ThenInclude(s => s.Grades)
                .ThenInclude(g => g.Student)
                .FirstOrDefaultAsync();

            return View(teacher);
        }
    }
}