﻿namespace BackendProj.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<Subject> Subjects { get; set; } // Dodajemy właściwość Subjects
}