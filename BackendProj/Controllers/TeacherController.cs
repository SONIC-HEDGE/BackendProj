using Microsoft.AspNetCore.Mvc;
using BackendProj.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendProj.Controllers;

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

    [HttpPost("/teacher/{teacherId}/student/{studentId}/subject/{subjectId}/grade")]
    public IActionResult EditGrade(int teacherId, int studentId, int subjectId, [FromForm] int gradeValue)
    {
        var grade = _context.Grades
            .FirstOrDefault(g => g.Student.Id == studentId && g.Subject.Id == subjectId);

        if (grade == null)
        {
            grade = new Grade
            {
                Student = _context.Students.Find(studentId),
                Subject = _context.Subjects.Find(subjectId),
                Value = gradeValue
            };
            _context.Grades.Add(grade);
        }
        else
        {
            grade.Value = gradeValue;
            _context.Grades.Update(grade);
        }

        _context.SaveChanges();

        return Ok();
    }
}