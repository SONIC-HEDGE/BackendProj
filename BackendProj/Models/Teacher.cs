﻿using System.Collections.Generic;

namespace BackendProj.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}