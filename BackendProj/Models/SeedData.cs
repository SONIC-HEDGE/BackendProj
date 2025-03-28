using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BackendProj.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(
                       serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                // Sprawdź, czy są już studenci w bazie danych
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }

                // Dodaj przykładowego nauczyciela
                var teacher = new Teacher
                {
                    Name = "Anna",
                    Surname = "Nowak"
                };
                context.Teachers.Add(teacher);
                context.SaveChanges();

                // Dodaj przykładowego studenta
                var student = new Student
                {
                    Name = "Jan",
                    Surname = "Kowalski"
                };
                context.Students.Add(student);
                context.SaveChanges();

                // Dodaj przedmioty i oceny dla studenta
                var subject = new Subject
                {
                    Name = "Matematyka",
                    Teacher = teacher,
                    Grades = new List<Grade>
                    {
                        new Grade { Value = 5, Student = student }
                    }
                };
                student.Subjects = new List<Subject> { subject };
                context.Subjects.Add(subject);
                context.SaveChanges();
            }
        }
    }
}