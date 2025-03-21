using Microsoft.AspNetCore.Mvc;
using BackendProj.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendProj.Controllers;

public class StudentController : Controller
{
    private readonly SchoolContext _context;

    public StudentController(SchoolContext context)
    {
        _context = context;
    }

    [HttpGet("/student/{id}")]
    public IActionResult Dashboard(int id)
    {
        var student = _context.Students
            .Include(s => s.Subjects)
            .ThenInclude(s => s.Grades)
            .FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
}